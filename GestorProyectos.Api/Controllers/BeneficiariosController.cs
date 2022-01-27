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
    public class BeneficiariosController : BaseController<Beneficiarios>
    {
        protected IUriService _uriService;
        protected IBeneficiariosService _currentService;

        public BeneficiariosController(IBeneficiariosService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos los Beneficiarios.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetBeneficiarios))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<BeneficiariosDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetBeneficiarios([FromQuery] BeneficiariosQueryFilter filters)
        {
            var result = await _currentService.ObtenerBeneficiarios(filters);
            var dto = _mapper.Map<IEnumerable<BeneficiariosDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve un Beneficiario en especifico.
        /// </summary>
        /// <param name="id">Id del Beneficiario.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerBeneficiario(id);
            var dto = _mapper.Map<BeneficiariosDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(BeneficiariosDto dtoModel)
        {
            var model = _mapper.Map<Beneficiarios>(dtoModel);
            var result = await _currentService.AgregarBeneficiario(model);
            dtoModel = _mapper.Map<BeneficiariosDto>(model);
            var data = await dtoModel.returnResponse();
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int Id, BeneficiariosDto dtoModel)
        {
            dtoModel.IdBeneficiario = Id;
            var result = await _currentService.ActualizarBeneficiario(_mapper.Map<Beneficiarios>(dtoModel));
            var data = await result.returnResponse();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _currentService.EliminarBeneficiario(id);
            var data = await result.returnResponse();
            return Ok(data);
        }

    }
}