using AutoMapper;
using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.DTOs;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using GestorProyectos.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace GestorProyectos.Api.Controllers
{
    public class DivisionTrabajoProyectosController : BaseController<DivisionTrabajoProyectos>
    {
        protected IUriService _uriService;
        protected IDivisionTrabajoProyectosService _currentService;

        public DivisionTrabajoProyectosController(IDivisionTrabajoProyectosService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos las DivisionTrabajoProyectos.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetDivisionTrabajoProyectos))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<DivisionTrabajoProyectosDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDivisionTrabajoProyectos([FromQuery] DivisionTrabajoProyectosQueryFilter filters)
        {
            var result = await _currentService.ObtenerDivision(filters);
            var dto = _mapper.Map<IEnumerable<DivisionTrabajoProyectosDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve una Division en especifico.
        /// </summary>
        /// <param name="id">Id de la Division.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerDivision(id);
            var dto = _mapper.Map<DivisionTrabajoProyectosDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }
    }
}