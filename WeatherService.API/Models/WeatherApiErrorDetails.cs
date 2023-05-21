using System.Net;

namespace WeatherService.API.Models;

/// <summary>
/// This class is a rough representation of the error object that the Weather API should always
/// return in case of an error. HttpStatusCode is added for convenience. 
/// See link for further details: https://www.weatherapi.com/docs/#intro-error-codes
/// </summary>
public class WeatherApiErrorDetails
{
    public Error Error { get; set; } = new Error();
    public HttpStatusCode? StatusCode { get; set; }
}

public class Error
{
    public int Code { get; set; }
    public string Message { get; set; } = string.Empty;
}
