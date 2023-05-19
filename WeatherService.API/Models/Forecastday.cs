namespace WeatherService.API.Models;

public class Forecastday
{
    public string Date { get; set; } = string.Empty;
    public long Date_Epoch { get; set; }
    public Day Day { get; set; } = new();
    public Astro Astro { get; set; } = new();
    public List<Hour> Hour { get; set; } = new();
}
