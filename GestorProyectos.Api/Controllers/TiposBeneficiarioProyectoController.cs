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
    public class TiposBeneficiarioProyectoController : BaseController<TiposBeneficiarioProyecto>
    {
        protected IUriService _uriService;
        protected ITiposBeneficiarioProyectoService _currentService;

        public TiposBeneficiarioProyectoController(ITiposBeneficiarioProyectoService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos las TiposBeneficiarioProyecto.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetTiposBeneficiarioProyecto))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<TiposBeneficiarioProyectoDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTiposBeneficiarioProyecto([FromQuery] TiposBeneficiarioProyectoQueryFilter filters)
        {
            var result = await _currentService.ObtenerTipo(filters);
            var dto = _mapper.Map<IEnumerable<TiposBeneficiarioProyectoDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve una Tipos en especifico.
        /// </summary>
        /// <param name="id">Id de la Tipos.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerTipo(id);
            var dto = _mapper.Map<TiposBeneficiarioProyectoDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }
    }
}