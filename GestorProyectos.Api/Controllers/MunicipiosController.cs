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
    public class MunicipiosController : BaseController<Municipios>
    {
        protected IUriService _uriService;
        protected IMunicipiosService _currentService;

        public MunicipiosController(IMunicipiosService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos los Municipios.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetMunicipios))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<MunicipiosDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetMunicipios([FromQuery] MunicipiosQueryFilter filters)
        {
            var result = await _currentService.ObtenerMunicipios(filters);
            var dto = _mapper.Map<IEnumerable<MunicipiosDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve un Municipio en especifico.
        /// </summary>
        /// <param name="id">Id del Municipio.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerMunicipio(id);
            var dto = _mapper.Map<MunicipiosDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }
    }
}