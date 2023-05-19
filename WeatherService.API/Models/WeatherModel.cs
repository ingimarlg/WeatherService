namespace WeatherService.API.Models;

public class WeatherModel
{
    public Location Location { get; set; } = new();
    public Current Current { get; set; } = new();
    public Forecast Forecast { get; set; } = new();
}
