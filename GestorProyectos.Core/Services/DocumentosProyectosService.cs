using GestorProyectos.Core.CustomModels;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class DocumentosProyectosService : IDocumentosProyectosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public DocumentosProyectosService(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }

        public async Task<DocumentosProyectos> ObtenerDocumento(int IdDocumento)
        {
            var query = await _unitOfWork.DocumentosProyectosRepository.GetAsync(e => e.IdDocumento == IdDocumento);
            var Documento = query.FirstOrDefault();
            return Documento;
        }

        public async Task<IEnumerable<DocumentosProyectos>> ObtenerDocumentos(DocumentosProyectosQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdDocumento != null && filters.IdDocumento != 0)
            {
                Expression<Func<DocumentosProyectos, bool>> query = (e => e.IdDocumento == filters.IdDocumento);
                expressions.Add(query);
            }
            if (filters.IdProyecto != null && filters.IdProyecto != 0)
            {
                Expression<Func<DocumentosProyectos, bool>> query = (e => e.IdProyecto == filters.IdProyecto);
                expressions.Add(query);
            }
            if (filters.IdTarea != null && filters.IdTarea != 0)
            {
                Expression<Func<DocumentosProyectos, bool>> query = (e => e.IdTarea == filters.IdTarea);
                expressions.Add(query);
            }

            var data = await _unitOfWork.DocumentosProyectosRepository.GetAsync(expressions);
            return data;
        }

        public async Task<DocumentosProyectos> AgregarDocumento(DocumentosProyectos documento)
        {
            documento.IdDocumento = 0;
            await _unitOfWork.DocumentosProyectosRepository.AddAsync(documento);
            return documento;
        }

        public async Task<bool> ActualizarDocumento(DocumentosProyectos documento)
        {
            var Documento = await ObtenerDocumento(documento.IdDocumento);
            if (Documento != null)
            {
                documento.CopyTo(Documento);
                _unitOfWork.DocumentosProyectosRepository.UpdateNoSave(Documento);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task GuardarDocumentos(IFormFile File, string CodigoProyecto)
        {
            string asd = _configuration["ProyectInfo:UploadDocument"];
            var webRootPath = Path.Combine(_hostingEnvironment.WebRootPath, asd);
            webRootPath = Path.Combine(webRootPath, CodigoProyecto);

            if (!Directory.Exists(webRootPath))
            {
                Directory.CreateDirectory(webRootPath);
            }

            string ruta = Path.Combine(webRootPath, File.FileName);
            await File.CopyToAsync(new FileStream(ruta, FileMode.Create));
        }

        public async Task<bool> EliminarDocumento(int IdDocumento)
        {
            var Documento = await ObtenerDocumento(IdDocumento);
            if (Documento != null)
            {
                _unitOfWork.DocumentosProyectosRepository.DeleteNoSave(Documento);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}