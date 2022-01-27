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
    public class SeccionesController : BaseController<Secciones>
    {
        protected IUriService _uriService;
        protected ISeccionesService _currentService;

        public SeccionesController(ISeccionesService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos las Secciones.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetSecciones))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<SeccionesDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetSecciones([FromQuery] SeccionesQueryFilter filters)
        {
            var result = await _currentService.ObtenerSecciones(filters);
            var dto = _mapper.Map<IEnumerable<SeccionesDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve una Sección en especifico.
        /// </summary>
        /// <param name="id">Id de la Sección.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerSeccion(id);
            var dto = _mapper.Map<SeccionesDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }
    }
}