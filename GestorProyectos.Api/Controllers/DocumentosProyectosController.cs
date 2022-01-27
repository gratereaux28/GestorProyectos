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
    public class DocumentosProyectosController : BaseController<DocumentosProyectos>
    {
        protected IUriService _uriService;
        protected IDocumentosProyectosService _currentService;

        public DocumentosProyectosController(IDocumentosProyectosService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos los Documentos asociados a los Proyectos.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetDocumentosProyectos))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<DocumentosProyectosDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetDocumentosProyectos([FromQuery] DocumentosProyectosQueryFilter filters)
        {
            var result = await _currentService.ObtenerDocumentos(filters);
            var dto = _mapper.Map<IEnumerable<DocumentosProyectosDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve un Documento en especifico asociado a un Proyecto.
        /// </summary>
        /// <param name="id">Id del Documento.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerDocumento(id);
            var dto = _mapper.Map<DocumentosProyectosDto>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(DocumentosProyectosDto dtoModel)
        {
            var model = _mapper.Map<DocumentosProyectos>(dtoModel);
            var result = await _currentService.AgregarDocumento(model);
            dtoModel = _mapper.Map<DocumentosProyectosDto>(model);
            var data = await dtoModel.returnResponse();
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int Id, DocumentosProyectosDto dtoModel)
        {
            dtoModel.IdDocumento = Id;
            var result = await _currentService.ActualizarDocumento(_mapper.Map<DocumentosProyectos>(dtoModel));
            var data = await result.returnResponse();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _currentService.EliminarDocumento(id);
            var data = await result.returnResponse();
            return Ok(data);
        }
    }
}