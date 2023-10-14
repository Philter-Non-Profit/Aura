using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.Net.Http.Headers;
using Philter.Aura.Data;
using Philter.Aura.Data.Models;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

var builder = WebApplication.CreateBuilder(new WebApplicationOptions
{
    Args = args,
    // Explicit declaration prevents ASP.NET Core from erroring if wwwroot doesn't exist at startup:
    WebRootPath = "wwwroot"
});

builder.Logging
    .AddConsole()
    // Filter out Request Starting/Request Finished noise:
    .AddFilter<ConsoleLoggerProvider>("Microsoft.AspNetCore.Hosting.Diagnostics", LogLevel.Warning);

builder.Configuration
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddEnvironmentVariables();

#region Configure Services

var services = builder.Services;

services.AddDbContext<AuraDbContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), opt => opt
        .EnableRetryOnFailure()
        .UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)
    )
    // Ignored because it interferes with the construction of Coalesce IncludeTrees via .Include()
    .ConfigureWarnings(warnings => warnings.Ignore(CoreEventId.NavigationBaseIncludeIgnored))
);

services.AddCoalesce<AuraDbContext>();

services
    .AddMvc()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });

const string SelectorScheme = $"{JwtBearerDefaults.AuthenticationScheme}_OR_{OpenIdConnectDefaults.AuthenticationScheme}";
services.AddAuthentication(auth =>
    {
        auth.DefaultScheme = SelectorScheme;
        // Clear specific defaults so they fall back on DefaultScheme.
        auth.DefaultChallengeScheme = auth.DefaultAuthenticateScheme = null;
    })

    // Add a scheme that will dynamically select the JWT scheme if a bearer token is present,
    // or the interactive browser AAD sign in scheme otherwise
    .AddPolicyScheme(SelectorScheme, SelectorScheme, options =>
    {
        options.ForwardDefaultSelector = context =>
        {
            string authorization = context.Request.Headers[HeaderNames.Authorization]!;
            if (!string.IsNullOrEmpty(authorization) && authorization.StartsWith("Bearer"))
            {
                return JwtBearerDefaults.AuthenticationScheme;
            }
            return OpenIdConnectDefaults.AuthenticationScheme;
        };
    })

    // Add handler for interactive browser AAD sign in
    .AddMicrosoftIdentityWebApp(options =>
    {
        options.ClientId = builder.Configuration["AzureAD:ClientId"];
        options.TenantId = builder.Configuration["AzureAD:TenantId"];
        options.Instance = builder.Configuration["AzureAD:Instance"]!;
        options.CallbackPath = builder.Configuration["AzureAD:CallbackPath"];
        options.ClientSecret = builder.Configuration["AzureAD:ClientSecret"];

        options.Events.OnRedirectToIdentityProvider = (context) =>
        {
            if ("XmlHttpRequest".Equals(context.Request.Headers.XRequestedWith, StringComparison.OrdinalIgnoreCase))
            {
                // Don't redirect AJAX/API requests. Just return a plain Unauthorized response.
                context.Response.StatusCode = 401;
                // TODO: Do we need a UserServices.ts for this?
                // This message is tested for in UserService.ts:
                context.Response.WriteAsJsonAsync<ItemResult>("You are not signed in.");
                context.HandleResponse();
            }
            return Task.CompletedTask;
        };

        options.Events.OnTicketReceived = (TicketReceivedContext trc) =>
        {
            // Get Email and check to make sure they are allowed to log in
            string? email = trc.Principal?.Identity?.Name;
            if (email == null)
            {
                trc.Fail("Invalid login");
                return Task.CompletedTask;
            }
            //
            // Get a database context and check if the user exists in the database
            AuraDbContext db = trc.HttpContext.RequestServices.GetRequiredService<AuraDbContext>();
            AuraUser? auraUser = db.Users.FirstOrDefault(f => f.Email == email);
            if (auraUser == null)
            {
                var name = trc.Principal?.Identities.First().Claims.First(x => x.Type == "name").Value
                       ?? throw new InvalidOperationException("Name is not included");

                auraUser = new AuraUser()
                {
                    Name = name,
                    Email = trc.Principal.Identity?.Name ?? throw new InvalidOperationException("Email is not included")
                };
                db.Users.Add(auraUser);
                db.SaveChanges();
            }
            trc.Success();

            return Task.CompletedTask;
        };
    });

builder.Services.AddRazorPages().AddMicrosoftIdentityUI();

#endregion

#region Configure HTTP Pipeline

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();

    app.UseViteDevelopmentServer(c =>
    {
        c.DevServerPort = 5002;
    });

    app.MapCoalesceSecurityOverview("coalesce-security");
}

app.UseAuthentication();
app.UseAuthorization();

var containsFileHashRegex = new Regex(@"\.[0-9a-fA-F]{8}\.[^\.]*$", RegexOptions.Compiled);
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = ctx =>
    {
        // vite puts 8-hex-char hashes before the file extension.
        // Use this to determine if we can send a long-term cache duration.
        if (containsFileHashRegex.IsMatch(ctx.File.Name))
        {
            ctx.Context.Response.GetTypedHeaders().CacheControl =
                new CacheControlHeaderValue { Public = true, MaxAge = TimeSpan.FromDays(30) };
        }
    }
});

// For all requests that aren't to static files, disallow caching by default.
// Individual endpoints may override this.
app.Use(async (context, next) =>
{
    context.Response.GetTypedHeaders().CacheControl =
        new CacheControlHeaderValue { NoCache = true, NoStore = true, };

    await next();
});

app.MapControllers();

// API fallback to prevent serving SPA fallback to 404 hits on API endpoints.
app.Map("/api/{**any}", () => Results.NotFound());

app.MapFallbackToController("Index", "Home");

#endregion



#region Launch

// Initialize/migrate database.
using (var scope = app.Services.CreateScope())
{
    var serviceScope = scope.ServiceProvider;

    // Run database migrations.
    using var db = serviceScope.GetRequiredService<AuraDbContext>();
    db.Database.Migrate();
}

app.Run();

#endregion
