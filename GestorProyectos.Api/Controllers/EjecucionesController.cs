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
    public class EjecucionesController : BaseController<Ejecuciones>
    {
        protected IUriService _uriService;
        protected IEjecucionesService _currentService;

        public EjecucionesController(IEjecucionesService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos las Ejecuciones.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetEjecuciones))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<EjecucionesDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetEjecuciones([FromQuery] EjecucionesQueryFilter filters)
        {
            var result = await _currentService.ObtenerEjecuciones(filters);
            var dto = _mapper.Map<IEnumerable<EjecucionesDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve un Ejecución en especifico.
        /// </summary>
        /// <param name="id">Id de la Ejecución.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerEjecucion(id);
            var dto = _mapper.Map<EjecucionesDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(EjecucionesDto dtoModel)
        {
            var model = _mapper.Map<Ejecuciones>(dtoModel);
            var result = await _currentService.AgregarEjecucion(model);
            dtoModel = _mapper.Map<EjecucionesDto>(model);
            var data = await dtoModel.returnResponse();
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int Id, EjecucionesDto dtoModel)
        {
            dtoModel.IdEjecucion = Id;
            var result = await _currentService.ActualizarEjecucion(_mapper.Map<Ejecuciones>(dtoModel));
            var data = await result.returnResponse();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _currentService.EliminarEjecucion(id);
            var data = await result.returnResponse();
            return Ok(data);
        }

    }
}