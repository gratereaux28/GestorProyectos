using AutoMapper;
using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.DTOs;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.Responses;
using GestorProyectos.Extensions.sys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net;
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
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<Estados>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest]
        public async Task<IActionResult> Get([FromQuery] EstadosQueryFilter filters)
        {
            IEnumerable<Estados> estados = await currentRepository.ObtenerEstados(filters);
            return Ok(estados.returnResponse());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Estados estados = await currentRepository.ObtenerEstado(id);
            return Ok(estados.returnResponse());
        }

        [HttpPost]
        public async Task<IActionResult> Post(EstadosDto estado)
        {
            var Estado = _mapper.Map<Estados>(estado);
            var result = await currentRepository.AgregarEstado(Estado);
            estado = _mapper.Map<EstadosDto>(Estado);
            return Ok(estado.returnResponse());
        }

        [HttpPut]
        public async Task<IActionResult> Put(int Id, EstadosDto estado)
        {
            estado.IdEstado = Id;
            var result = await currentRepository.ActualizarEstado(_mapper.Map<Estados>(estado));
            return Ok(result.returnResponse());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await currentRepository.EliminarEstado(Id);
            return Ok(result.returnResponse());
        }

    }
}