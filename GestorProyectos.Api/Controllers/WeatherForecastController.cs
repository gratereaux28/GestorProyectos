using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestorProyectos.Api.Controllers
{
    public class WeatherForecastController : BaseController<WeatherForecastController, WeatherForecast>
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        public WeatherForecastController(IWeatherForecastRepository weatherForecastRepository) : base()
        {
            _weatherForecastRepository = weatherForecastRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_weatherForecastRepository.Get());
        }
    }
}