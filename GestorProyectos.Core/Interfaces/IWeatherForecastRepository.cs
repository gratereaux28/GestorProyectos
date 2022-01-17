using GestorProyectos.Base.Interfaces;
using GestorProyectos.Core.Models;

namespace GestorProyectos.Core.Interfaces
{
    public interface IWeatherForecastRepository : IBaseRepository<WeatherForecast>
    {
        IEnumerable<WeatherForecast> Get();
    }
}
