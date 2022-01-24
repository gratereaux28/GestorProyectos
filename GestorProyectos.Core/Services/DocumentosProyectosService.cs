using GestorProyectos.Core.CustomModels;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class DocumentosProyectosService : IDocumentosProyectosService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DocumentosProyectosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

        public async Task<DocumentosProyectos> AgregarDocumento(DocumentosProyectos estado)
        {
            estado.IdDocumento = 0;
            return await _unitOfWork.DocumentosProyectosRepository.AddAsync(estado);
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