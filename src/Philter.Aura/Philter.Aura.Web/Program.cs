using IntelliTect.Coalesce;
using IntelliTect.Coalesce.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.Net.Http.Headers;
using Philter.Aura.Data;
using Philter.Aura.Data.Models;
using Philter.Aura.Data.Services;
using Philter.Aura.Data.Helpers;
using Philter.Aura.Data.Options;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Twilio;
using System.Threading.Tasks;
using System.Linq;

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
    .AddUserSecrets<Program>(true)
    .AddEnvironmentVariables();

builder.Host.AddTwilioClient();

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
services.AddScoped<IMessagingService, MessagingService>();

services
    .AddMvc()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
var initialScopes = builder.Configuration["DownstreamApi:Scopes"]?.Split(' ') ??
    builder.Configuration["MicrosoftGraph:Scopes"]?.Split(' ');

services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApp(options =>
    {
        builder.Configuration.GetSection("AzureAd").Bind(options);

        options.Events.OnRedirectToIdentityProvider = (context) =>
        {
            if ("XmlHttpRequest".Equals(context.Request.Headers.XRequestedWith, StringComparison.OrdinalIgnoreCase))
            {
                // Don't redirect AJAX/API requests. Just return a plan Unauthorized response.
                context.Response.StatusCode = 401;
                context.Response.WriteAsJsonAsync<ItemResult>("You are not signed in.");
                context.HandleResponse();
            }
            return Task.CompletedTask;
        };
        options.Events.OnTicketReceived = (TicketReceivedContext trc) =>
        {
            // Create a new app user for the logging in user
            AuraDbContext db = trc.HttpContext.RequestServices.GetRequiredService<AuraDbContext>();

            if (Guid.TryParse(trc.Principal?.Identities.FirstOrDefault()?.Claims
                .FirstOrDefault(claim => claim.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value, out Guid azureObjectId))
            {
                var appUser = db.Users.FirstOrDefault(appUser => appUser.AuraUserId == azureObjectId);
                if (appUser is null)
                {
                    // Create a new user
                    var name = trc.Principal?.Identities.First().Claims.First(claim => claim.Type == "name").Value
                        ?? throw new InvalidOperationException("Principal first name is unexpectedly null");

                    var email = trc.Principal?.Identity?.Name
                        ?? throw new InvalidOperationException("Principal email is unexpectedly null");

                    appUser = new AuraUser()
                    {
                        Name = name,
                        Email = email,
                        AuraUserId = azureObjectId,
                    };

                    db.Users.Add(appUser);
                    db.SaveChanges();
                }

                trc.Success();
                trc.Principal = trc.Principal.GetNewClaimsPrincipal(appUser);
                Console.WriteLine($"Successfully Logged in user: {appUser.Name}");
                return Task.CompletedTask;
            }
            else
            {
                trc.Fail("Invalid login, an Azure object id is required");
                return Task.CompletedTask;
            }
        };
    })
    .EnableTokenAcquisitionToCallDownstreamApi(initialScopes)
    .AddMicrosoftGraph(builder.Configuration.GetSection("MicrosoftGraph"))
    .AddInMemoryTokenCaches();

services.AddRazorPages().AddMicrosoftIdentityUI();

services.AddAuthorization(options =>
{
    // By default, all incoming requests will be authorized according the the default policy
    options.FallbackPolicy = options.DefaultPolicy;
});

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

var options = app.Services.GetRequiredService<IOptions<TwilioOptions>>();
TwilioClient.Init(options.Value.AccountSid, options.Value.AuthToken);

app.Run();

#endregion
