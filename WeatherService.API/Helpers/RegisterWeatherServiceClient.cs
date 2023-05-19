using WeatherService.API.Clients;

namespace WeatherService.API.Helpers;
public static class RegisterWeatherServices
{
    public static IServiceCollection AddWeatherServices(this IServiceCollection services, IConfiguration configuration)
    {
        var baseAddress = configuration.GetValue<string>("WeatherApi:BaseAddress");
        if (string.IsNullOrWhiteSpace(baseAddress))
        {
            throw new InvalidOperationException("WeatherApi:BaseAddress is not set in configuration");
        }

        var apiKey = configuration.GetValue<string>("WeatherApi:ApiKey");
        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException("WeatherApi:ApiKey is not set in configuration");
        }

        services.AddSingleton(sp => new WeatherServiceUriBuilder(baseAddress, apiKey));

        services.AddHttpClient<IWeatherServiceClient, WeatherServiceClient>();

        return services;
    }
}
