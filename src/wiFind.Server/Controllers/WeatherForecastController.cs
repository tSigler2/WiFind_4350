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
            //for (var i = 0; i < 3; i++)
            //{
            //var u = new User()
            //{
            //    first_name = "test user " + i.ToString(),
            //    last_name = "abc",
            //    dob = DateOnly.FromDateTime(DateTime.Now),
            //    email = "demostudent@student.gsu.edu",
            //    phone_number = "1234567890",
            //};
            //// add in-memory
            //_wiFindContext.Add(u);
            // wifFindContext.SaveChanges();
            //}

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
