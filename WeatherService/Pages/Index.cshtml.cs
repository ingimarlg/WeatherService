using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WeatherService.API.Clients;
using WeatherService.API.Exceptions;
using WeatherService.API.Models;
using WeatherService.Pages.Shared;

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

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        _logger.LogInformation("Executing request to fetch data");
        try
        {
            if (FetchType == "Current")
            {
                CurrentWeatherData = await _weatherServiceClient.FetchCurrentWeather(City);
            }
            else if (FetchType == "Forecast")
            {
                ForecastData = await _weatherServiceClient.FetchForecast(City, ForecastDays);
            }
            else if (FetchType == "History")
            {
                if (Date.HasValue)
                {
                    HistoricalData = await _weatherServiceClient.FetchHistoricalWeather(City, Date.Value.ToString(_DATEFORMAT));
                }
            }

            return Page();
        }
        catch (WeatherApiException ex)
        {
            _logger.LogError(ex, "Exception when fetching data");

            TempData[Constants.WEATHER_API_ERROR_CODE] = ex.ErrorDetails.Error.Code;
            TempData[Constants.ERROR_MESSAGE] = ex.ErrorDetails.Error.Message;
            TempData[Constants.HTTP_STATUS_CODE] = ex.ErrorDetails.StatusCode;

            return RedirectToPage("Error");
        }
        catch (InternalServerException ex)
        {
            _logger.LogError($"{ex.Message} \nInner exception: {ex.InnerException}");

            TempData[Constants.ERROR_MESSAGE] = ex.Message;

            return RedirectToPage("Error");
        }
        catch (Exception ex) 
        {
            _logger.LogError($"UNKNOWN exception cought when fetching data! Call the devs! Where are the handcuffs?! {ex.Message} \nInner exception: {ex.InnerException}");

            TempData[Constants.ERROR_MESSAGE] = "UNKNOWN exception cought when fetching data! Call the devs! Where are the handcuffs?!";

            return RedirectToPage("Error");
        }
    }
}
