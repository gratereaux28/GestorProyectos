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
    public class DesafiosProyectosController : BaseController<DesafiosProyectos>
    {
        protected IUriService _uriService;
        protected IDesafiosProyectosService _currentService;

        public DesafiosProyectosController(IDesafiosProyectosService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos los Desafios asociados a los Proyectos.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetDesafiosProyectos))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<DesafiosProyectosDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDesafiosProyectos([FromQuery] DesafiosProyectosQueryFilter filters)
        {
            var result = await _currentService.ObtenerDesafiosProyectos(filters);
            var dto = _mapper.Map<IEnumerable<DesafiosProyectosDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve un Desafio en especifico asociado a un Proyecto.
        /// </summary>
        /// <param name="id">Id del Desafio.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerDesafio(id);
            var dto = _mapper.Map<DesafiosProyectosDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DesafiosProyectosDto dtoModel)
        {
            var model = _mapper.Map<DesafiosProyectos>(dtoModel);
            var result = await _currentService.AgregarDesafio(model);
            dtoModel = _mapper.Map<DesafiosProyectosDto>(model);
            var data = await dtoModel.returnResponse();
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int Id, DesafiosProyectosDto dtoModel)
        {
            dtoModel.IdDesafioProyecto = Id;
            var result = await _currentService.ActualizarDesafio(_mapper.Map<DesafiosProyectos>(dtoModel));
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