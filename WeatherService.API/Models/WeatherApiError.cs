using System.Text;

namespace WeatherService.API.Models;

/// <summary>
/// This class is a rough representation of the error object that the Weather API should always
/// return in case of an error. See link below for further details.
/// https://www.weatherapi.com/docs/#intro-error-codes
/// </summary>
public class WeatherApiError
{
    public Error Error { get; set; } = new Error();

    public override string ToString()
    {
        StringBuilder sb = new();

        sb.Append("An error occured in the Weather Api: [Code: ");
        sb.Append(Error.Code);

        sb.Append(", Message: ");
        sb.Append(Error.Message);

        sb.Append(']');

        return sb.ToString();
    }
}

public class Error
{
    public int Code { get; set; }
    public string Message { get; set; } = string.Empty;
}
