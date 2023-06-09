using Microsoft.AspNetCore.Mvc;
using WeatherService.API.Clients;

namespace WeatherService.Controllers;

[ApiController]
[Route("/")]
public class WeatherServiceController : ControllerBase
{
    private readonly ILogger<WeatherServiceController> _logger;
    private readonly IWeatherServiceClient _weatherApiClient;

    private const string _DATEFORMAT = "yyyy-MM-dd";

    public WeatherServiceController(ILogger<WeatherServiceController> logger, IWeatherServiceClient weatherApiClient)
    {
        _logger = logger;
        _weatherApiClient = weatherApiClient;
    }

    [HttpGet("weather/{city}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCurrentWeather(string city = "London")
    {
        _logger.LogInformation("Executing {method} for city {city}", 
            nameof(GetCurrentWeather), 
            city);

        if (string.IsNullOrWhiteSpace(city))
        {
            return BadRequest("City name cannot be null or whitespace.");
        }

        var weatherData = await _weatherApiClient.FetchCurrentWeather(city);
        if (weatherData == null)
        {
            return NotFound("Weather data could not be found for the provided city.");
        }

        return Ok(weatherData);
    }

    [HttpGet("weather/{city}/forecast")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetForecast(string city = "London")
    {
        _logger.LogInformation("Executing {method} for city {city}",
            nameof(GetForecast),
            city);

        if (string.IsNullOrEmpty(city))
        {
            return BadRequest("City name cannot be null or empty.");
        }

        var result = await _weatherApiClient.FetchForecast(city);

        if (result == null)
        {
            return NotFound("Forecast data could not be found for the provided city.");
        }

        return Ok(result);
    }

    [HttpGet("weather/{city}/history/{date}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetHistoricalWeather(string city = "London", string date = "2023-05-19")
    {
        _logger.LogInformation("Executing {method} for city {city} and date {date}",
            nameof(GetHistoricalWeather),
            city,
            date);

        if (string.IsNullOrWhiteSpace(city))
        {
            return BadRequest("City name cannot be null or empty.");
        }

        var dateValidationResult = ValidateDate(date);
        if (dateValidationResult != null)
        {
            return BadRequest(dateValidationResult);
        }

        //var parsedDate = DateOnly.ParseExact(date, _DATEFORMAT, CultureInfo.InvariantCulture);
        //DateTime parsedDate = DateTime.Parse(date);
        var result = await _weatherApiClient.FetchHistoricalWeather(city, date);

        if (result == null)
        {
            return NotFound("Historical weather data could not be found for the provided city and date.");
        }

        return Ok(result);
    }

    private static string? ValidateDate(string date)
    {
        if (!DateOnly.TryParseExact(date, _DATEFORMAT, out var parsedDate))
        {
            return $"Invalid date format. Please provide a date in the format '{_DATEFORMAT}'.";
        }

        string MinimumDate = DateTime.Now.AddDays(-7).ToString(_DATEFORMAT);
        if (parsedDate < DateOnly.Parse(MinimumDate))
        {
            return $"Invalid date. We can't provide data for dates later than one week ago. Please provide another date that is within last 7 days.";
        }

        string todayDate = DateTime.Now.ToString(_DATEFORMAT);
        if (parsedDate > DateOnly.Parse(todayDate))
        {
            return "Don't you want to fetch forecast instead? Please provide another date.";
        }

        return null;
    }
}
