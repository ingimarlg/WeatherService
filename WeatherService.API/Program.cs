using Microsoft.Extensions.Options;
using WeatherService.API.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddWeatherServices(builder.Configuration);

builder.Services.AddControllers();

// Add Endpoints API Explorer service which is required for the Swagger
//builder.Services.AddEndpointsApiExplorer();

// Add Swagger services
//builder.Services.AddSwaggerGen();

//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new() { Title = "WeatherService.API", Version = "v1" });
//});

var app = builder.Build();

// Enable middleware to serve generated Swagger as a JSON endpoint
//app.UseSwagger();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    //app.UseExceptionHandler("/Home/Error");
    //app.UseHsts();

    // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
    // specifying the Swagger JSON endpoint
    //app.UseSwaggerUI();
    //app.UseSwaggerUI(c =>
    //{
    //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeatherService.API v1");
    //    //c.RoutePrefix = string.Empty;
    //});
//}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
