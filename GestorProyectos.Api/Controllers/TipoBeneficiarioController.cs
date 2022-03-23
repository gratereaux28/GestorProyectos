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
    public class TipoBeneficiarioController : BaseController<TipoBeneficiario>
    {
        protected IUriService _uriService;
        protected ITipoBeneficiarioService _currentService;

        public TipoBeneficiarioController(ITipoBeneficiarioService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos las TipoBeneficiario.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetTipoBeneficiario))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<TipoBeneficiarioDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTipoBeneficiario([FromQuery] TipoBeneficiarioQueryFilter filters)
        {
            var result = await _currentService.ObtenerTipo(filters);
            var dto = _mapper.Map<IEnumerable<TipoBeneficiarioDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve una Tipo en especifico.
        /// </summary>
        /// <param name="id">Id de la Tipo.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerTipo(id);
            var dto = _mapper.Map<TipoBeneficiarioDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }
    }
}