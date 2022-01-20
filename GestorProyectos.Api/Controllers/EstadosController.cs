using AutoMapper;
using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.DTOs;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GestorProyectos.Api.Controllers
{
    public class EstadosController : CrudBaseController<IEstadosRepository, Estados>
    {
        public EstadosController(IEstadosRepository repository, ILogger<Estados> logger, IMapper mapper) : base(repository)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await currentRepository.ListAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post(EstadosDto estado)
        {
            await currentRepository.AgregarEstados(_mapper.Map<Estados>(estado));
            return Ok(estado);
        }
    }
}