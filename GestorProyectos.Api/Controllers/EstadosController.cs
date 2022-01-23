﻿using AutoMapper;
using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.DTOs;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.Entity;
using GestorProyectos.Extensions.Responses;
using GestorProyectos.Extensions.sys;
using GestorProyectos.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace GestorProyectos.Api.Controllers
{
    public class EstadosController : BaseController<EstadosController, Estados>
    {
        protected IUriService _uriService;
        protected IEstadosService _estadosService;
        public EstadosController(IEstadosService estadosService, ILogger<EstadosController> logger, IMapper mapper, IUriService uriService) : base()
        {
            _estadosService = estadosService;
            _logger = logger;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos los estados.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(Get))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<EstadosDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get([FromQuery] EstadosQueryFilter filters)
        {
            var estados = await _estadosService.ObtenerEstados(filters);
            var estadosDto = _mapper.Map<IEnumerable<EstadosDto>>(estados);

            var metadata = new Metadata
            {
                TotalCount = estados.TotalCount,
                PageSize = estados.PageSize,
                CurrentPage = estados.CurrentPage,
                TotalPages = estados.TotalPages,
                HasNextPage = estados.HasNextPage,
                HasPreviousPage = estados.HasPreviousPage,
                NextPageUrl = _uriService.GetEstadosPaginationUri(filters, Url.RouteUrl(nameof(Get))).ToString(),
                PreviousPageUrl = _uriService.GetEstadosPaginationUri(filters, Url.RouteUrl(nameof(Get))).ToString()
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(estadosDto.returnResponse(metadata));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstado(int id)
        {
            Estados estados = await _estadosService.ObtenerEstado(id);
            return Ok(estados.returnResponse());
        }

        [HttpPost]
        public async Task<IActionResult> Post(EstadosDto estado)
        {
            var Estado = _mapper.Map<Estados>(estado);
            var result = await _estadosService.AgregarEstado(Estado);
            estado = _mapper.Map<EstadosDto>(Estado);
            return Ok(estado.returnResponse());
        }

        [HttpPut]
        public async Task<IActionResult> Put(int Id, EstadosDto estado)
        {
            estado.IdEstado = Id;
            var result = await _estadosService.ActualizarEstado(_mapper.Map<Estados>(estado));
            return Ok(result.returnResponse());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var result = await _estadosService.EliminarEstado(Id);
            return Ok(result.returnResponse());
        }

    }
}