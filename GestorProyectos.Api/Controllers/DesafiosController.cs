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
    public class DesafiosController : BaseController<Desafios>
    {
        protected IUriService _uriService;
        protected IDesafiosService _currentService;

        public DesafiosController(IDesafiosService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos los desafíos.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetDesafios))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<DesafiosDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDesafios([FromQuery] DesafiosQueryFilter filters)
        {
            var desafios = await _currentService.ObtenerDesafios(filters);
            var desafiosDto = _mapper.Map<IEnumerable<DesafiosDto>>(desafios);
            var data = await desafiosDto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve un Desafio en especifico.
        /// </summary>
        /// <param name="id">Id del Desafio.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerDesafio(id);
            var dto = _mapper.Map<DesafiosDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DesafiosDto desafio)
        {
            var Desafio = _mapper.Map<Desafios>(desafio);
            var result = await _currentService.AgregarDesafio(Desafio);
            desafio = _mapper.Map<DesafiosDto>(Desafio);
            var data = await desafio.returnResponse();
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int Id, DesafiosDto desafio)
        {
            desafio.IdDesafio = Id;
            var result = await _currentService.ActualizarDesafio(_mapper.Map<Desafios>(desafio));
            var data = await result.returnResponse();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _currentService.EliminarDesafio(id);
            var data = await result.returnResponse();
            return Ok(data);
        }

    }
}