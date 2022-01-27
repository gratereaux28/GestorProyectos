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
    public class TareasController : BaseController<Tareas>
    {
        protected IUriService _uriService;
        protected ITareasService _currentService;

        public TareasController(ITareasService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos las Tareas.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetTareas))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<TareasDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTareas([FromQuery] TareasQueryFilter filters)
        {
            var result = await _currentService.ObtenerTareas(filters);
            var dto = _mapper.Map<IEnumerable<TareasDto>>(result);
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
            var result = await _currentService.ObtenerTarea(id);
            var dto = _mapper.Map<TareasDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TareasDto dtoModel)
        {
            var model = _mapper.Map<Tareas>(dtoModel);
            var result = await _currentService.AgregarTarea(model);
            dtoModel = _mapper.Map<TareasDto>(model);
            var data = await dtoModel.returnResponse();
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int Id, TareasDto dtoModel)
        {
            dtoModel.IdTarea = Id;
            var result = await _currentService.ActualizarTarea(_mapper.Map<Tareas>(dtoModel));
            var data = await result.returnResponse();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _currentService.EliminarTarea(id);
            var data = await result.returnResponse();
            return Ok(data);
        }
    }
}