using GestorProyectos.Core.CustomModels;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class TareasService : ITareasService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TareasService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Tareas> ObtenerTarea(int IdTarea)
        {
            var query = await _unitOfWork.TareasRepository.AddInclude("Responsable").AddInclude("Estado").GetAsync(e => e.IdTarea == IdTarea);
            var Tarea = query.FirstOrDefault();
            return Tarea;
        }

        public async Task<IEnumerable<Tareas>> ObtenerTareas(TareasQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdTarea != null && filters.IdTarea != 0)
            {
                Expression<Func<Tareas, bool>> query = (e => e.IdTarea == filters.IdTarea);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.Descripcion))
            {
                Expression<Func<Tareas, bool>> query = (e => e.Descripcion.ToLower().Contains(filters.Descripcion.ToLower()));
                expressions.Add(query);
            }
            if (filters.IdProyecto != null && filters.IdProyecto != 0)
            {
                Expression<Func<Tareas, bool>> query = (e => e.IdProyecto == filters.IdProyecto);
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
            if (filters.IdEstado != null && filters.IdEstado != 0)
            {
                Expression<Func<Tareas, bool>> query = (e => e.IdEstado == filters.IdEstado);
                expressions.Add(query);
            }

            var data = await _unitOfWork.TareasRepository.AddInclude("Responsable").AddInclude("Estado").GetAsync(expressions);
            return data;
        }

        public async Task<Tareas> AgregarTarea(Tareas tarea)
        {
            tarea.IdTarea = 0;
            return await _unitOfWork.TareasRepository.AddAsync(tarea);
        }

        public async Task<bool> ActualizarTarea(Tareas tarea)
        {
            var Tarea = await ObtenerTarea(tarea.IdTarea);
            if (Tarea != null)
            {
                tarea.CopyTo(Tarea);
                _unitOfWork.TareasRepository.UpdateNoSave(Tarea);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> EliminarTarea(int IdTarea)
        {
            var Tarea = await ObtenerTarea(IdTarea);
            if (Tarea != null)
            {
                _unitOfWork.TareasRepository.DeleteNoSave(Tarea);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}