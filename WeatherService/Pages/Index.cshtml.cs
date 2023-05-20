using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeatherService.API.Clients;
using WeatherService.API.Models;

public class IndexModel : PageModel
{
    private readonly IWeatherServiceClient _weatherServiceClient;
    private readonly ILogger<IndexModel> _logger;
    private const string _DATEFORMAT = "yyyy-MM-dd";

    public IndexModel(ILogger<IndexModel> logger, IWeatherServiceClient weatherServiceClient)
    {
        _logger = logger;
        _weatherServiceClient = weatherServiceClient;
    }

    public WeatherModel? CurrentWeatherData { get; set; }
    public WeatherModel? ForecastData { get; set; }
    public WeatherModel? HistoricalData { get; set; }

    [BindProperty(SupportsGet = true)]
    public string City { get; set; } = string.Empty;

    [BindProperty(SupportsGet = true)]
    public DateTime? Date { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? ForecastDays { get; set; } = 3;

    [BindProperty]
    public string FetchType { get; set; } = string.Empty;

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task OnPostAsync()
    {
        if (FetchType == "Current")
        {
            try
            {
                CurrentWeatherData = await _weatherServiceClient.FetchCurrentWeather(City);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception when fetching current data");
            }
        }
        else if (FetchType == "Forecast")
        {
            try
            {
                ForecastData = await _weatherServiceClient.FetchForecast(City, ForecastDays);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception when fetching forecast data");
            }
        }
        else if (FetchType == "History")
        {
            try
            {
                if (Date.HasValue)
                {
                    HistoricalData = await _weatherServiceClient.FetchHistoricalWeather(City, Date.Value.ToString(_DATEFORMAT));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception when fetching historical data");
            }
        }
    }
}
