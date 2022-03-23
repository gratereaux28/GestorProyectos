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
    public class NivelAccesoController : BaseController<NivelAcceso>
    {
        protected IUriService _uriService;
        protected INivelAccesoService _currentService;

        public NivelAccesoController(INivelAccesoService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos las NivelAcceso.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetNivelAcceso))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<NivelAccesoDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetNivelAcceso([FromQuery] NivelAccesoQueryFilter filters)
        {
            var result = await _currentService.ObtenerNivel(filters);
            var dto = _mapper.Map<IEnumerable<NivelAccesoDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve una Nivel en especifico.
        /// </summary>
        /// <param name="id">Id de la Nivel.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerNivel(id);
            var dto = _mapper.Map<NivelAccesoDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }
    }
}