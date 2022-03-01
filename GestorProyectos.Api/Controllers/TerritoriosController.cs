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
    public class TerritoriosController : BaseController<TerritoriosImpactados>
    {
        protected IUriService _uriService;
        protected ITerritoriosImpactadosService _currentService;

        public TerritoriosController(ITerritoriosImpactadosService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] TerritoriosQueryFilter querySFilters)
        {
            var result = await _currentService.ObtenerListaTerritoriosImpactados(querySFilters);
            var data = await result.returnResponse();
            return Ok(data);
        }
    }
}