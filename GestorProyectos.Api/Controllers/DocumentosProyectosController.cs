using AutoMapper;
using GestorProyectos.Api.Models;
using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.DTOs;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using GestorProyectos.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GestorProyectos.Api.Controllers
{
    public class DocumentosProyectosController : BaseController<DocumentosProyectos>
    {
        protected IUriService _uriService;
        protected IDocumentosProyectosService _currentService;
        protected IProyectosService _proyectosService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public DocumentosProyectosController(IDocumentosProyectosService currentService, IMapper mapper, IUriService uriService, IProyectosService proyectosService,
            IWebHostEnvironment hostingEnvironment, IConfiguration configuration) : base()
        {
            _currentService = currentService;
            _proyectosService = proyectosService;
            _mapper = mapper;
            _uriService = uriService;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
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

        //[HttpPost]
        //public async Task<IActionResult> Post(DocumentosProyectosDto dtoModel)
        //{
        //    var model = _mapper.Map<DocumentosProyectos>(dtoModel);
        //    var result = await _currentService.AgregarDocumento(model);
        //    dtoModel = _mapper.Map<DocumentosProyectosDto>(model);
        //    var data = await dtoModel.returnResponse();
        //    return Ok(data);
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromForm] DocumentosProyectoFile documento)
        {
            await _currentService.GuardarDocumentos(documento.File, documento.CodigoProyecto);
            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> DescargarDocumento(int id)
        {
            var documento = await _currentService.ObtenerDocumentoWithInclude(id);

            string route = _configuration["ProyectInfo:UploadDocument"];
            var webRootPath = System.IO.Path.Combine(_hostingEnvironment.WebRootPath, route);
            webRootPath = System.IO.Path.Combine(webRootPath, documento.Proyecto.Codigo);
            webRootPath = System.IO.Path.Combine(webRootPath, documento.NombreArchivo);
            var data = System.IO.File.ReadAllBytes(webRootPath);
            var content = new System.IO.MemoryStream(data);
            var contentType = "APPLICATION/octet-stream";
            return File(content, contentType, documento.NombreArchivo);
        }

        [HttpPut("{id}")]
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