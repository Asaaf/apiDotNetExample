using Microsoft.AspNetCore.Mvc;

namespace ApiDotNet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
        if (ListWeatherForecast == null || !ListWeatherForecast.Any())
        {
            InitList();
        }
    }

    [HttpGet(Name = "GetWeatherForecast")]
    [Route("ruta1/prueba1")]//Ruta personalizada
    [Route("ruta2/prueba2")]//Otra ruta personalizada
    [Route("[action]")]//Ruta para acceder usando el nombre del método
    public IEnumerable<WeatherForecast> Get()
    {
        _logger.LogInformation("Retornando la lista de weather forecast");//Muestra por consola un mensaje
        _logger.LogDebug("Retornando la lista de weather forecast");//Muestra por consola un mensaje siempre y cuando appsettings.json tenga habilitado el logLevel en Debug
        return ListWeatherForecast;
    }

    [HttpPost]
    public IActionResult Post(WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);
        return Ok();
    }

    [HttpPut]
    public IActionResult Put(WeatherForecast weatherForecast)
    {
        ListWeatherForecast.Add(weatherForecast);
        //Ciclo run y luego condicional para buscar el registro que quiero cambiar
        return Ok();
    }

    [HttpDelete("{index}")]
    public IActionResult Delete(int index)
    {
        ListWeatherForecast.RemoveAt(index);
        return Ok();
    }

    public void InitList()
    {
        ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
            .ToList();
    }
}
