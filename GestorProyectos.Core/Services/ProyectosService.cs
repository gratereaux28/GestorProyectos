using GestorProyectos.Core.DTOs;
using GestorProyectos.Core.Exceptions;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class ProyectosService : IProyectosService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IConfiguration _configuration;

        public ProyectosService(IUnitOfWork unitOfWork, IHostingEnvironment hostingEnvironment, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _configuration = configuration;
        }

        public async Task<Proyectos> ObtenerProyecto(int IdProyecto)
        {
            var repo = _unitOfWork.ProyectosRepository;
            repo.AddInclude("DesafiosProyectos");
            repo.AddInclude("DocumentosProyectos");
            repo.AddInclude("LugaresImplementaciones");
            repo.AddInclude("Tareas");
            repo.AddInclude("Tareas.Responsable");
            repo.AddInclude("Tareas.Estado");
            repo.AddInclude("TerritoriosImpactados");
            var query = await repo.GetAsync(e => e.IdProyecto == IdProyecto);
            var Proyecto = query.FirstOrDefault();
            return Proyecto;
        }

        public async Task<IEnumerable<Proyectos>> ObtenerProyectos(ProyectosQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdProyecto != null && filters.IdProyecto != 0)
            {
                Expression<Func<Proyectos, bool>> query = (e => e.IdProyecto == filters.IdProyecto);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Codigo))
            {
                Expression<Func<Proyectos, bool>> query = (e => e.Codigo.ToLower().Contains(filters.Codigo.ToLower()));
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Nombre))
            {
                Expression<Func<Proyectos, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Descripcion))
            {
                Expression<Func<Proyectos, bool>> query = (e => e.Descripcion.ToLower().Contains(filters.Descripcion.ToLower()));
                expressions.Add(query);
            }
            if (filters.FechaInicio != null && filters.FechaFinal != null)
            {
                Expression<Func<Proyectos, bool>> query = (e => e.FechaInicio >= filters.FechaInicio && e.FechaFinal <= filters.FechaFinal);
                expressions.Add(query);
            }
            else if (filters.FechaInicio != null)
            {
                Expression<Func<Proyectos, bool>> query = (e => e.FechaInicio == filters.FechaInicio);
                expressions.Add(query);
            }
            else if (filters.FechaFinal != null)
            {
                Expression<Func<Proyectos, bool>> query = (e => e.FechaFinal == filters.FechaFinal);
                expressions.Add(query);
            }

            Expression<Func<Proyectos, bool>> delete = (e => !e.IsDelete.Value);
            expressions.Add(delete);

            var repo = _unitOfWork.ProyectosRepository;
            repo.AddInclude("Tareas");
            var data = await repo.GetAsync(expressions);
            return data;
        }

        public async Task<Proyectos> AgregarProyecto(Proyectos proyecto, IEnumerable<DocumentosProyectosDto> documentos)
        {
            proyecto.IdProyecto = 0;
            _unitOfWork.ProyectosRepository.AddNoSave(proyecto);
            await _unitOfWork.SaveChangesAsync();

            return proyecto;
        }

        public async Task<bool> ActualizarProyecto(Proyectos proyecto, IEnumerable<DocumentosProyectosDto> documentos)
        {
            var webRootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration["ProyectInfo:UploadDocument"]);
            string contentRootPath = _hostingEnvironment.ContentRootPath;

            try
            {
                var Proyecto = await ObtenerProyecto(proyecto.IdProyecto);
                if (Proyecto != null)
                {
                    var documentosEliminados = Proyecto.DocumentosProyectos.Where(d => !documentos.Select(dp => dp.IdDocumento).Contains(d.IdDocumento)).ToList();

                    proyecto.CopyTo(Proyecto);
                    _unitOfWork.ProyectosRepository.UpdateNoSave(Proyecto);
                    await _unitOfWork.SaveChangesAsync();

                    webRootPath = Path.Combine(webRootPath, proyecto.Codigo);

                    if (!Directory.Exists(webRootPath))
                        Directory.CreateDirectory(webRootPath);

                    foreach (var doc in documentosEliminados)
                    {
                        string ruta = Path.Combine(webRootPath, doc.NombreArchivo);
                        File.Delete(ruta);
                    }

                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> EliminarProyecto(int IdProyecto)
        {
            var ejecucion = await _unitOfWork.EjecucionesRepository.GetAsync(e => e.IdProyecto == IdProyecto);
            if (ejecucion != null && ejecucion.Count() > 0)
            {
                throw new BusinessException("Existe una Ejecucion atada a este Proyecto.");
            }

            var Proyecto = await ObtenerProyecto(IdProyecto);
            if (Proyecto != null)
            {
                //_unitOfWork.ProyectosRepository.DeleteNoSave(Proyecto);
                //await _unitOfWork.SaveChangesAsync();
                //var webRootPath = Path.Combine(_hostingEnvironment.WebRootPath, _configuration["ProyectInfo:UploadDocument"]);
                //webRootPath = Path.Combine(webRootPath, Proyecto.Codigo);
                //if (Directory.Exists(webRootPath))
                //    Directory.Delete(webRootPath, true);
                Proyecto.IsDelete = true;
                _unitOfWork.ProyectosRepository.UpdateNoSave(Proyecto);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}