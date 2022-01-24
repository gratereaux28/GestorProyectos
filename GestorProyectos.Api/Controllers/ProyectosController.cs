﻿using AutoMapper;
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
    public class ProyectosController : BaseController<Proyectos>
    {
        protected IUriService _uriService;
        protected IProyectosService _currentService;

        public ProyectosController(IProyectosService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos los Proyectos.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetProyectos))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ProyectosDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetProyectos([FromQuery] ProyectosQueryFilter filters)
        {
            var result = await _currentService.ObtenerProyectos(filters);
            var dto = _mapper.Map<IEnumerable<ProyectosDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProyectosDto dtoModel)
        {
            var model = _mapper.Map<Proyectos>(dtoModel);
            var result = await _currentService.AgregarProyecto(model);
            dtoModel = _mapper.Map<ProyectosDto>(model);
            var data = await dtoModel.returnResponse();
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int Id, ProyectosDto dtoModel)
        {
            dtoModel.IdProyecto = Id;
            var result = await _currentService.ActualizarProyecto(_mapper.Map<Proyectos>(dtoModel));
            var data = await result.returnResponse();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _currentService.EliminarProyecto(id);
            var data = await result.returnResponse();
            return Ok(data);
        }
    }
}