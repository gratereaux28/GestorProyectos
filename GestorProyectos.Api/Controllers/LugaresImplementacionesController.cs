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
    public class LugaresImplementacionesController : BaseController<LugaresImplementaciones>
    {
        protected IUriService _uriService;
        protected ILugaresImplementacionesService _currentService;

        public LugaresImplementacionesController(ILugaresImplementacionesService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos las Implementaciones.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetImplementaciones))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<LugaresImplementacionesDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetImplementaciones([FromQuery] LugaresImplementacionesQueryFilter filters)
        {
            var result = await _currentService.ObtenerLugaresImplementaciones(filters);
            var dto = _mapper.Map<IEnumerable<LugaresImplementacionesDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve una Implementación en especifico.
        /// </summary>
        /// <param name="id">Id de la Implementación.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerImplementacion(id);
            var dto = _mapper.Map<LugaresImplementacionesDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(LugaresImplementacionesDto dtoModel)
        {
            var model = _mapper.Map<LugaresImplementaciones>(dtoModel);
            var result = await _currentService.AgregarImplementacion(model);
            dtoModel = _mapper.Map<LugaresImplementacionesDto>(model);
            var data = await dtoModel.returnResponse();
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int Id, LugaresImplementacionesDto dtoModel)
        {
            dtoModel.IdImplementacion = Id;
            var result = await _currentService.ActualizarImplementacion(_mapper.Map<LugaresImplementaciones>(dtoModel));
            var data = await result.returnResponse();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _currentService.EliminarImplementacion(id);
            var data = await result.returnResponse();
            return Ok(data);
        }

    }
}