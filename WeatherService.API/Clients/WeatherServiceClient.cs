using WeatherService.API.Models;
using WeatherService.API.Helpers;

namespace WeatherService.API.Clients;

public class WeatherServiceClient : IWeatherServiceClient
{
    private readonly ILogger<WeatherServiceClient> _logger;
    private readonly HttpClient _httpClient;
    private readonly WeatherServiceUriBuilder _uriBuilder;

    public WeatherServiceClient(ILogger<WeatherServiceClient> logger, HttpClient httpClient, WeatherServiceUriBuilder uriBuilder)
    {
        _logger = logger;
        _httpClient = httpClient;
        _uriBuilder = uriBuilder;
    }

    public Task<string> FetchCurrentWeather(string city)
    {
        _logger.LogInformation("Fetching current weather data for city {city}", city);
        return FetchWeatherData(_uriBuilder.BuildCurrentWeatherUri(city));
    }

    public Task<string> FetchForecast(string city)
    {
        _logger.LogInformation("Fetching weather forecast data for city {city}", city);
        return FetchWeatherData(_uriBuilder.BuildForecastWeatherUri(city));
    }

    public Task<string> FetchHistoricalWeather(string city, DateOnly date)
    {
        _logger.LogInformation("Fetching historical weather data for city {city} and date {date}", city, date);
        return FetchWeatherData(_uriBuilder.BuildHistoryWeatherUri(city, date));
    }

    private async Task<string> FetchWeatherData(Uri requestUri)
    {
        HttpResponseMessage response = new();
        try
        {
            response = await _httpClient.GetAsync(requestUri);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            await HandleHttpRequestException(ex, response);
        }

        return await response.Content.ReadAsStringAsync();
    }

    private async Task HandleHttpRequestException(HttpRequestException ex, HttpResponseMessage response)
    {
        var error = await response.Content.ReadFromJsonAsync<WeatherApiError>();
        if (error != null)
        {
            throw new HttpRequestException(error.ToString());
        }
        else
        {
            throw ex;
        }
    }
}
