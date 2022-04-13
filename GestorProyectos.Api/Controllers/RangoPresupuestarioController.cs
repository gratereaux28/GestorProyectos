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
    public class RangoPresupuestarioController : BaseController<RangoPresupuestario>
    {
        protected IUriService _uriService;
        protected IRangoPresupuestarioService _currentService;

        public RangoPresupuestarioController(IRangoPresupuestarioService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos las RangoPresupuestario.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetRangoPresupuestario))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<RangoPresupuestarioDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetRangoPresupuestario([FromQuery] RangoPresupuestarioQueryFilter filters)
        {
            var result = await _currentService.ObtenerRango(filters);
            var dto = _mapper.Map<IEnumerable<RangoPresupuestarioDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve una Rango en especifico.
        /// </summary>
        /// <param name="id">Id de la Rango.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerRango(id);
            var dto = _mapper.Map<RangoPresupuestarioDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }
    }
}