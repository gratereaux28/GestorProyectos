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
    public class DonantesController : BaseController<Donantes>
    {
        protected IUriService _uriService;
        protected IDonantesService _currentService;

        public DonantesController(IDonantesService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos las Donantes.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetDonantes))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<DonantesDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDonantes([FromQuery] DonantesQueryFilter filters)
        {
            var result = await _currentService.ObtenerDonante(filters);
            var dto = _mapper.Map<IEnumerable<DonantesDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve una Donante en especifico.
        /// </summary>
        /// <param name="id">Id de la Donante.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerDonante(id);
            var dto = _mapper.Map<DonantesDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }
    }
}