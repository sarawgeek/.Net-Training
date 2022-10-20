using AppWithFilter.Filters;
using ApWithFilter.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ApWithFilter.Controllers
{
    [MyCustomFilter("Controller", 2)]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [MyCustomFilter("Method", 0)]
        [Route("Custom1")]
        [HttpGet]
        public string GetCustom()
        {
            return "Custom 1";
        }

        [MyAsyncCustomFilter("AsyncMethod")]
        [Route("Custom2")]
        [HttpGet]
        public string GetCustom2()
        {
            return "Custom 2";
        }
    }
}