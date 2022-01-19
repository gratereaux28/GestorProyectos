using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GestorProyectos.Api.Controllers
{
    public class BarriosController : CrudBaseController<IBarriosRepository, Barrios>
    {
        private readonly ILogger<Barrios> _logger;

        public BarriosController(IBarriosRepository repository, ILogger<Barrios> logger) : base(repository)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            currentRepository.AddInclude("Secciones");
            return Ok(base.GetAll());
        }
    }
}
