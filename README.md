# WeatherService

WeatherService is a .NET Core solution designed to provide weather data for different locations. It consists of two primary components: a frontend ASP.NET Core Web App (WeatherService) and a backend ASP.NET Core Web API (WeatherService.API).

> **_NOTE:_** The two projects can be run simultaneously or one by one. These instructions show how to run each.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/en-us/download) (Installs automatically with Visual Studio)
- An IDE or editor (like Visual Studio, Visual Studio Code, or Rider)
- An internet connection

### Setup

1. Clone this repository to your local machine.
2. Open the WeatherService solution in your IDE or editor.
3. Right click on the project WeatherService.API and select "Manage User Secrets".
4. I know that secrets should NEVER go here, and that I should tell you to create an account on https://www.weatherapi.com and get an API key. Anyway, just copy the "secret" below and paste it into the secrets.json file
```json
{
  "WeatherApi": {
    "ApiKey": "bab455886f9d4dfe96a151345231705"
  }
}
```

### Running the REST API

1. Ensure that `WeatherService.API` is set as the startup project. You can do this in Visual Studio by right-clicking on the `WeatherService.API` project in the Solution Explorer and selecting "Set as StartUp Project".

2. Run the solution.

3. You should see the a browser open up with the url `https://localhost:7019/swagger/index.html` where you should see the Swagger UI.

4. Go nuts

5. If you want to skip the Swagger UI and see the raw json in the browser, then you can change the path from `swagger/index.html` to the following:
	- **For Current Weather**: Use the path `/weather/{city}` to get the current weather information for the specified city.
	- **For Forecast Weather**: Use the path `/weather/{city}/forecast` to get the forecasted weather information for the specified city.
	- **For Historical Weather**: Use the path `/weather/{city}/history/{date}` to get the historical weather information for the specified city and date.

### Running the Web App

1. Ensure that `WeatherService` is set as the startup project.

2. Run the solution.

3. You should see the WeatherService web application open up in a browser with the url `https://localhost:7073`

4. Go nuts

## Built With

- [.NET 6.0](https://dotnet.microsoft.com/download/dotnet/6.0) - The framework used

## Powered by

- [Weather API](https://www.weatherapi.com/) - The API that our solution wraps

## Author

- Ingimar <ins>**Logi Guðlaugsson**</ins> (ekki hinn Ingimar)
