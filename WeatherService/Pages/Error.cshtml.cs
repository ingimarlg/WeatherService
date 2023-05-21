using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;
using WeatherService.Pages.Shared;

namespace WeatherService.Pages
{
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    [IgnoreAntiforgeryToken]
    public class ErrorModel : PageModel
    {
        private readonly ILogger<ErrorModel> _logger;

        public string? ErrorMessage { get; set; }
        public new HttpStatusCode? StatusCode { get; set; }
        public int? StatusCodeNumber { get; set; }
        public string? WeatherApiErrorCode { get; set; }

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            //RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;

            if (TempData[Constants.WEATHER_API_ERROR_CODE] != null)
            {
                WeatherApiErrorCode = TempData[Constants.WEATHER_API_ERROR_CODE].ToString();
            }
            
            if (TempData[Constants.HTTP_STATUS_CODE] != null)
            {
                StatusCode = (HttpStatusCode)TempData[Constants.HTTP_STATUS_CODE];

                StatusCodeNumber = (int)StatusCode;
            }
            
            if (TempData[Constants.ERROR_MESSAGE] != null)
            {
                ErrorMessage = TempData[Constants.ERROR_MESSAGE].ToString();
            }
            else
            {
                ErrorMessage = "Unknown error occured, please try again";
            }
        }

        public void OnPost()
        {
            Response.Redirect("/");
        }
    }
}
