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
    public class DistritosMunicipalesController : BaseController<DistritosMunicipales>
    {
        protected IUriService _uriService;
        protected IDistritosMunicipalesService _currentService;

        public DistritosMunicipalesController(IDistritosMunicipalesService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos los Distritos Municipales.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetDistritosMunicipales))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<DistritosMunicipalesDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDistritosMunicipales([FromQuery] DistritosMunicipalesQueryFilter filters)
        {
            var result = await _currentService.ObtenerDistritosMunicipales(filters);
            var dto = _mapper.Map<IEnumerable<DistritosMunicipalesDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve un Distrito en especifico.
        /// </summary>
        /// <param name="id">Id del Distrito.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerDistritoMunicipal(id);
            var dto = _mapper.Map<DistritosMunicipalesDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DistritosMunicipalesDto dtoModel)
        {
            var model = _mapper.Map<DistritosMunicipales>(dtoModel);
            var result = await _currentService.AgregarDistritoMunicipal(model);
            dtoModel = _mapper.Map<DistritosMunicipalesDto>(model);
            var data = await dtoModel.returnResponse();
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int Id, DistritosMunicipalesDto dtoModel)
        {
            dtoModel.IdDistrito = Id;
            var result = await _currentService.ActualizarDistritoMunicipal(_mapper.Map<DistritosMunicipales>(dtoModel));
            var data = await result.returnResponse();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _currentService.EliminarDistritoMunicipal(id);
            var data = await result.returnResponse();
            return Ok(data);
        }

    }
}