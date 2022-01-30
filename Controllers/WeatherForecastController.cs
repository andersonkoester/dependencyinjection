using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using WebAPIDI.Repository;

namespace WebAPIDI.Controllers;

[ApiController]
[Route("weather")]
[Produces("application/json")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IWeatherRepository _repository;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherRepository repository, IConfiguration configuration)
    {
        _logger = logger;
        _repository = repository;
        _logger.LogInformation(JsonSerializer.Serialize(configuration.GetChildren()));
    }

    /// <summary>
    /// Retrieves a specific product by unique id
    /// </summary>
    /// <remarks>Awesomeness!</remarks>
    /// <response code="200">Product created</response>
    /// <response code="400">Product has missing/invalid values</response>
    /// <response code="500">Oops! Can't create your product right now</response>
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.Log(LogLevel.Information, "Eu sou um log por DI");
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
    
    /// <summary>
    /// TESTT  
    /// </summary>
    /// <remarks>Awesomeness!</remarks>
    /// <response code="200">Product created</response>
    /// <response code="400">Product has missing/invalid values</response>
    /// <response code="500">Oops! Can't create your product right now</response>
    [HttpGet(template:"Test", Name = "Teste")]
    public WeatherForecast Test()
    {
        // _logger.LogDebug(new Exception("Erro Debug"), "Xinelage");
        // _logger.Log(LogLevel.Critical, "LogLevel.Critical");
        // _logger.Log(LogLevel.Debug, "LogLevel.Debug");
        // _logger.Log(LogLevel.Error, "LogLevel.Error");
        // _logger.Log(LogLevel.Information, "LogLevel.Information");
        // _logger.Log(LogLevel.None, "LogLevel.None");
        // _logger.Log(LogLevel.Trace, "LogLevel.Trace");
        // _logger.Log(LogLevel.Warning, "LogLevel.Warning");
        return _repository.GetWeatherByCity("Cidade");
    }
}