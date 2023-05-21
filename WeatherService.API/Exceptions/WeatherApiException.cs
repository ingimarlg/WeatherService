using WeatherService.API.Models;

namespace WeatherService.API.Exceptions;

public class WeatherApiException : Exception
{
    public WeatherApiErrorDetails ErrorDetails { get; set; } = new();

    public WeatherApiException() { }

    public WeatherApiException(string message) : base(message) { }

    public WeatherApiException(WeatherApiErrorDetails errorDetails, string message)
        : base(message)
    {
        ErrorDetails = errorDetails;
    }
}
