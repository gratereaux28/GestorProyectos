using AutoMapper;
using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.DTOs;
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
    public class BarriosController : BaseController<BarriosController, Barrios>
    {
        protected readonly IUriService _uriService;
        private readonly IBarriosService _barriosService;
        public BarriosController(IBarriosService barriosService, ILogger<BarriosController> logger, IMapper mapper, IUriService uriService) : base()
        {
            _barriosService = barriosService;
            _logger = logger;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos los barrios.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet(Name = nameof(GetBarrrios))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<BarriosDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetBarrrios([FromQuery] BarriosQueryFilter filters)
        {
            var barrios = await _barriosService.ObtenerBarrios(filters);
            var barriosDto = _mapper.Map<IEnumerable<BarriosDto>>(barrios);

            var metadata = new Metadata
            {
                TotalCount = barrios.TotalCount,
                PageSize = barrios.PageSize,
                CurrentPage = barrios.CurrentPage,
                TotalPages = barrios.TotalPages,
                HasNextPage = barrios.HasNextPage,
                HasPreviousPage = barrios.HasPreviousPage,
                NextPageUrl = barrios.HasNextPage ? _uriService.GetPaginationUri(filters, barrios.PageSize, barrios.CurrentPage + 1, Url.RouteUrl(nameof(GetBarrrios))).ToString() : "",
                PreviousPageUrl = barrios.HasPreviousPage ? _uriService.GetPaginationUri(filters, barrios.PageSize, barrios.CurrentPage - 1, Url.RouteUrl(nameof(GetBarrrios))).ToString() : ""
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(barriosDto.returnResponse(metadata));
        }
    }
}