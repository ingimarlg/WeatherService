using WeatherService.API.Models;

namespace WeatherService.API.Clients;

public interface IWeatherServiceClient
{
    Task<WeatherModel> FetchCurrentWeather(string city);
    Task<WeatherModel> FetchForecast(string city, int? days = null);
    Task<WeatherModel> FetchHistoricalWeather(string city, string date);
}
