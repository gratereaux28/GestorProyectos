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
    public class ActividadesController : BaseController<Actividades>
    {
        protected IUriService _uriService;
        protected IActividadesService _currentService;

        public ActividadesController(IActividadesService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos las Actividades.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetActividades))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ActividadesDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetActividades([FromQuery] ActividadesQueryFilter filters)
        {
            var result = await _currentService.ObtenerActividad(filters);
            var dto = _mapper.Map<IEnumerable<ActividadesDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve una Actividad en especifico.
        /// </summary>
        /// <param name="id">Id de la Actividad.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerActividad(id);
            var dto = _mapper.Map<ActividadesDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }
    }
}