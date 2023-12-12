using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

using ExceptionAttribute.Attributes;

[ThrowExceptionHere(typeof(TempForecastController))]
[ApiController]
[Route("[controller]")]
public class TempForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "5","10", "20", "30", "40"
    };

    private readonly ILogger<TempForecastController> _logger;

    public TempForecastController(ILogger<TempForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetTempForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5)
            .Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}