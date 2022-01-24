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
    public class ProvinciasController : BaseController<Provincias>
    {
        protected IUriService _uriService;
        protected IProvinciasService _currentService;

        public ProvinciasController(IProvinciasService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos las Provincias.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetProvincias))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ProvinciasDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetProvincias([FromQuery] ProvinciasQueryFilter filters)
        {
            var result = await _currentService.ObtenerProvincias(filters);
            var dto = _mapper.Map<IEnumerable<ProvinciasDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }
    }
}