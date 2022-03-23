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
    public class AliadoClasificacionesController : BaseController<AliadoClasificaciones>
    {
        protected IUriService _uriService;
        protected IAliadoClasificacionesService _currentService;

        public AliadoClasificacionesController(IAliadoClasificacionesService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos las AliadoClasificaciones.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetAliadoClasificaciones))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<AliadoClasificacionesDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAliadoClasificaciones([FromQuery] AliadoClasificacionesQueryFilter filters)
        {
            var result = await _currentService.ObtenerClasificacion(filters);
            var dto = _mapper.Map<IEnumerable<AliadoClasificacionesDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve una Clasificacion en especifico.
        /// </summary>
        /// <param name="id">Id de la Clasificacion.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerClasificacion(id);
            var dto = _mapper.Map<AliadoClasificacionesDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }
    }
}