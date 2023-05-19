namespace WeatherService.API.Models;

public class Location
{
    public string Name { get; set; } = string.Empty;
    public string Region { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public float Lat { get; set; }
    public float Lon { get; set; }
    public string Tz_Id { get; set; } = string.Empty;
    public long Localtime_Epoch { get; set; }
    public string Localtime { get; set; } = string.Empty;
}
