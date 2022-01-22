using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestorProyectos.Api.Controllers
{
    public class WeatherForecastController : CrudBaseController<IWeatherForecastRepository, WeatherForecast>
    {
        public WeatherForecastController(IWeatherForecastRepository repository, ILogger<WeatherForecast> logger) : base(repository)
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
