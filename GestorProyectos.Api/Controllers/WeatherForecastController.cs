using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestorProyectos.Api.Controllers
{
    public class WeatherForecastController : CrudBaseController<IWeatherForecastRepository, WeatherForecast>
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(IWeatherForecastRepository repository, ILogger<WeatherForecastController> logger) : base(repository)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(currentRepository.Get());
        }
    }
}
