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
    public class TerritoriosImpactadosController : BaseController<TerritoriosImpactados>
    {
        protected IUriService _uriService;
        protected ITerritoriosImpactadosService _currentService;

        public TerritoriosImpactadosController(ITerritoriosImpactadosService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos los Territorios Impactados asociados al Proyecto.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetTerritoriosImpactados))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<TerritoriosImpactadosDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetTerritoriosImpactados([FromQuery] TerritoriosImpactadosQueryFilter filters)
        {
            var result = await _currentService.ObtenerTerritoriosImpactados(filters);
            var dto = _mapper.Map<IEnumerable<TerritoriosImpactadosDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(TerritoriosImpactadosDto dtoModel)
        {
            var model = _mapper.Map<TerritoriosImpactados>(dtoModel);
            var result = await _currentService.AgregarImpacto(model);
            dtoModel = _mapper.Map<TerritoriosImpactadosDto>(model);
            var data = await dtoModel.returnResponse();
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int Id, TerritoriosImpactadosDto dtoModel)
        {
            dtoModel.IdImpacto = Id;
            var result = await _currentService.ActualizarImpacto(_mapper.Map<TerritoriosImpactados>(dtoModel));
            var data = await result.returnResponse();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _currentService.EliminarImpacto(id);
            var data = await result.returnResponse();
            return Ok(data);
        }
    }
}