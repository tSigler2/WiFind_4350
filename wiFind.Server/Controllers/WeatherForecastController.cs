using Microsoft.AspNetCore.Mvc;

namespace wiFind.Server.Controllers
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
        private readonly WiFindContext _wiFindContext;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, WiFindContext wiFindContext)
        {
            _logger = logger;
            _wiFindContext = wiFindContext;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            // Do this in a separate 'seedDbController'
            // drop all existing records
            // seed with new records
            var obj = new User()
            {
                nickname = "obj"
            };
            // add in-memory
            _wiFindContext.Add(obj);
            // save to db
            _wiFindContext.SaveChanges();
            // CRUD commands with db context...

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
