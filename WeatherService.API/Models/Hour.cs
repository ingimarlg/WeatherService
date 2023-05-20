namespace WeatherService.API.Models;

public class Hour
{
    public long Time_Epoch { get; set; }
    public string Time { get; set; } = string.Empty;
    public float Temp_C { get; set; }
    public float Temp_F { get; set; }
    public int Is_Day { get; set; }
    public Condition Condition { get; set; } = new();
    public float Wind_Mph { get; set; }
    public float Wind_Kph { get; set; }
    public int Wind_Degree { get; set; }
    public string Wind_Dir { get; set; } = string.Empty;
    public float Pressure_Mb { get; set; }
    public float Pressure_In { get; set; }
    public float Precip_Mm { get; set; }
    public float Precip_In { get; set; }
    public int Humidity { get; set; }
    public int Cloud { get; set; }
    public float Feelslike_C { get; set; }
    public float Feelslike_F { get; set; }
    public float Windchill_C { get; set; }
    public float Windchill_F { get; set; }
    public float Heatindex_C { get; set; }
    public float Heatindex_F { get; set; }
    public float Dewpoint_C { get; set; }
    public float Dewpoint_F { get; set; }
    public int Will_It_Rain { get; set; }
    public int Chance_Of_Rain { get; set; }
    public int Will_It_Snow { get; set; }
    public int Chance_Of_Snow { get; set; }
    public float Vis_Km { get; set; }
    public float Vis_Miles { get; set; }
    public float Gust_Mph { get; set; }
    public float Gust_Kph { get; set; }
    public float Uv { get; set; }
}