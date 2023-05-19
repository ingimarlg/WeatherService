namespace WeatherService.API.Models;

public class Astro
{
    public string Sunrise { get; set; } = string.Empty;
    public string Sunset { get; set; } = string.Empty;
    public string Moonrise { get; set; } = string.Empty;
    public string Moonset { get; set; } = string.Empty;
    public string Moon_Phase { get; set; } = string.Empty;
    public string Moon_Illumination { get; set; } = string.Empty;
    public int Is_Moon_Up { get; set; }
    public int Is_Sun_Up { get; set; }
}
