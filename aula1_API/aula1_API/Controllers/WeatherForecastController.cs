using Microsoft.AspNetCore.Mvc;

namespace aula1_API.Controllers
{
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

        [HttpGet]
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
        [HttpGet("Tempo")]
        public WeatherForecast ConsultaTempo()
        {
            return  new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            } ;
        }
        [HttpPost("Tempo")]
        public void InserirTempo(WeatherForecast parametro)
        {
            Console.WriteLine("Adiciona Aqui");
        }
       

        [HttpDelete("Tempo")]
        public void ApagaTempo(WeatherForecast parametro)
        {
            Console.WriteLine("Apaga Tempo Aqui");
        }

        [HttpPut("Tempo")]
        public void AtualizaTempo(WeatherForecast parametro)
        {
            Console.WriteLine("Atualiza Tempo Aqui");
        }
    }
}