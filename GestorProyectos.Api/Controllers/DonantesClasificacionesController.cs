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
    public class DonantesClasificacionesController : BaseController<DonantesClasificaciones>
    {
        protected IUriService _uriService;
        protected IDonantesClasificacionesService _currentService;

        public DonantesClasificacionesController(IDonantesClasificacionesService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos las DonantesClasificaciones.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetDonantesClasificaciones))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<DonantesClasificacionesDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDonantesClasificaciones([FromQuery] DonantesClasificacionesQueryFilter filters)
        {
            var result = await _currentService.ObtenerClasificacion(filters);
            var dto = _mapper.Map<IEnumerable<DonantesClasificacionesDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve una Donante en especifico.
        /// </summary>
        /// <param name="id">Id de la Clasificacion.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerClasificacion(id);
            var dto = _mapper.Map<DonantesClasificacionesDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }
    }
}