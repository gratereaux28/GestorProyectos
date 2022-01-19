using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GestorProyectos.Api.Controllers
{
    public class EstadosController : CrudBaseController<IEstadosRepository, Estados>
    {
        private readonly ILogger<Estados> _logger;

        public EstadosController(IEstadosRepository repository, ILogger<Estados> logger) : base(repository)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(currentRepository.ListAll());
        }

        [HttpPost]
        public async Task<IActionResult> Post(Estados estado)
        {
            await currentRepository.AgregarEstados(estado);
            return Ok(estado);
        }
    }
}
