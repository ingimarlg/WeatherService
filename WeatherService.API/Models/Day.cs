namespace WeatherService.API.Models;

public class Day
{
    public float Maxtemp_C { get; set; }
    public float Maxtemp_F { get; set; }
    public float Mintemp_C { get; set; }
    public float Mintemp_F { get; set; }
    public float Avgtemp_C { get; set; }
    public float Avgtemp_F { get; set; }
    public float Maxwind_Mph { get; set; }
    public float Maxwind_Kph { get; set; }
    public float Totalprecip_Mm { get; set; }
    public float Totalprecip_In { get; set; }
    public float Totalsnow_Cm { get; set; }
    public float Avgvis_Km { get; set; }
    public float Avgvis_Miles { get; set; }
    public float Avghumidity { get; set; }
    public int Daily_Will_It_Rain { get; set; }
    public string Daily_Chance_Of_Rain { get; set; } = string.Empty;
    public int Daily_Will_It_Snow { get; set; }
    public string Daily_Chance_Of_Snow { get; set; } = string.Empty;
    public Condition Condition { get; set; } = new();
    public float Uv { get; set; }
}
