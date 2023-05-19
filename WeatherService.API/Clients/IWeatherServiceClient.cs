namespace WeatherService.API.Clients;

public interface IWeatherServiceClient
{
    Task<string> FetchCurrentWeather(string city);
    Task<string> FetchForecast(string city);
    Task<string> FetchHistoricalWeather(string city, DateOnly date);
}
