namespace WeatherService.API.Models;

public class Forecast
{
    public List<Forecastday> Forecastday { get; set; } = new();
}
