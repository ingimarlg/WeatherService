using WeatherService.API.Models;
using WeatherService.API.Helpers;
using System.Text.Json;

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

    public async Task<WeatherModel> FetchCurrentWeather(string city)
    {
        _logger.LogInformation("Fetching current weather data for city {city}", city);

        var weatherModel = await FetchWeatherData(_uriBuilder.BuildCurrentWeatherUri(city));
        ArgumentNullException.ThrowIfNull(weatherModel, $"The {nameof(weatherModel)} cannot be null");
        return weatherModel;
    }

    public async Task<WeatherModel> FetchForecast(string city, int? days = null)
    {
        _logger.LogInformation("Fetching weather forecast data for city {city}", city);

        var weatherModel = await FetchWeatherData(_uriBuilder.BuildForecastWeatherUri(city, days));
        ArgumentNullException.ThrowIfNull(weatherModel, $"The {nameof(weatherModel)} cannot be null");
        return weatherModel;
    }

    public async Task<WeatherModel> FetchHistoricalWeather(string city, string date)
    {
        _logger.LogInformation("Fetching historical weather data for city {city} and date {date}", city, date);
        var weatherModel = await FetchWeatherData(_uriBuilder.BuildHistoryWeatherUri(city, date));
        ArgumentNullException.ThrowIfNull(weatherModel, $"The {nameof(weatherModel)} cannot be null");
        return weatherModel;
    }

    private async Task<WeatherModel?> FetchWeatherData(Uri requestUri)
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

        try
        {
            return await response.Content.ReadFromJsonAsync<WeatherModel>();
        }
        catch (JsonException)
        {
            throw;
        }
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
