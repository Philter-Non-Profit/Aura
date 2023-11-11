using Philter.Aura.Web.Twilio;

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