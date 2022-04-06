using AutoMapper;
using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.DTOs;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.Entity;
using GestorProyectos.Extensions.Responses;
using GestorProyectos.Extensions.sys;
using GestorProyectos.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace GestorProyectos.Api.Controllers
{
    public class BarriosController : BaseController<Barrios>
    {
        protected readonly IUriService _uriService;
        private readonly IBarriosService _barriosService;
        public BarriosController(IBarriosService barriosService, IMapper mapper, IUriService uriService) : base()
        {
            _barriosService = barriosService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos los barrios.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetBarrrios))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<BarriosDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetBarrrios([FromQuery] BarriosQueryFilter filters)
        {
            var result = await _barriosService.ObtenerBarrios(filters);
            var dto = _mapper.Map<IEnumerable<BarriosDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve un Barrio en especifico.
        /// </summary>
        /// <param name="id">Id del Barrio.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _barriosService.ObtenerBarrio(id);
            var dto = _mapper.Map<BarriosDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }
    }
}