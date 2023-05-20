using System.Web;

namespace WeatherService.API.Helpers;
public class WeatherServiceUriBuilder
{
    private readonly string _baseAddress;
    private readonly string _apiKey;

    public WeatherServiceUriBuilder(string baseAddress, string apiKey)
    {
        _baseAddress = baseAddress;
        _apiKey = apiKey;
    }

    internal Uri BuildCurrentWeatherUri(string city)
    {
        var builder = new UriBuilder(_baseAddress)
        {
            Path = $"/v1/current.json",
            Query = $"key={_apiKey}&q={HttpUtility.UrlEncode(city)}"
        };

        return builder.Uri;
    }

    internal Uri BuildForecastWeatherUri(string city, int? days = null)
    {
        var builder = new UriBuilder(_baseAddress)
        {
            Path = $"/v1/forecast.json",
            Query = $"key={_apiKey}&q={HttpUtility.UrlEncode(city)}" + (days.HasValue ? $"&days={days}" : string.Empty)
        };

        return builder.Uri;
    }

    internal Uri BuildHistoryWeatherUri(string city, string date)
    {
        var builder = new UriBuilder(_baseAddress)
        {
            Path = $"/v1/history.json",
            Query = $"key={_apiKey}&q={HttpUtility.UrlEncode(city)}&date={date}"
        };

        return builder.Uri;
    }
}
