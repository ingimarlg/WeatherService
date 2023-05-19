namespace WeatherService.API.Helpers;
public static class WeatherServiceDateFormat
{
    private const string _DATEFORMAT = "yyyy-MM-dd";

    /// <summary>
    /// Formats a DateTime object into a string in the format yyyy-MM-dd
    /// </summary>
    /// <remarks>
    /// This is the format that WeatherAPI allows.
    /// </remarks>
    /// <returns>String of a date with the format yyyy-MM-dd</returns>
    public static string History(this DateOnly date)
    {
        try
        {
            string result = date.ToString(_DATEFORMAT);
            return result;
        }
        catch (Exception)
        {
            throw;
        }
    }
}
