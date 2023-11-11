using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Philter.Aura.Web.TwilioSvc;

public static class TwilioClientModule
{
    public static IHostBuilder AddTwilioClient(this IHostBuilder builder)
    {
        builder.ConfigureServices((context, services) =>
        {
            var configurationRoot = context.Configuration;
            AddClient(services, configurationRoot);
        });
        return builder;
    }

    public static void AddClient(IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<TwilioOptions>(configuration.GetSection(nameof(TwilioOptions)));
        services.AddScoped<TwilioHelper>();
    }
}