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
    public class AliadoController : BaseController<Aliado>
    {
        protected IUriService _uriService;
        protected IAliadoService _currentService;

        public AliadoController(IAliadoService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos las Aliado.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetAliado))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<AliadoDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAliado([FromQuery] AliadoQueryFilter filters)
        {
            var result = await _currentService.ObtenerAliado(filters);
            var dto = _mapper.Map<IEnumerable<AliadoDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve una Tarea en especifico.
        /// </summary>
        /// <param name="id">Id de la Tarea.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerAliado(id);
            var dto = _mapper.Map<AliadoDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(AliadoDto dtoModel)
        {
            var model = _mapper.Map<Aliado>(dtoModel);
            var result = await _currentService.AgregarAliado(model);
            dtoModel = _mapper.Map<AliadoDto>(result);
            var data = await dtoModel.returnResponse();
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int Id, AliadoDto dtoModel)
        {
            dtoModel.IdAliado = Id;
            var aliado = _mapper.Map<Aliado>(dtoModel);
            var result = await _currentService.ActualizarAliado(aliado);
            var data = await result.returnResponse();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _currentService.EliminarAliado(id);
            var data = await result.returnResponse();
            return Ok(data);
        }
    }
}