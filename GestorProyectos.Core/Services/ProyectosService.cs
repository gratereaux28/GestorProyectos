using GestorProyectos.Core.Exceptions;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class ProyectosService : IProyectosService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProyectosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Proyectos> ObtenerProyecto(int IdProyecto)
        {
            var repo = _unitOfWork.ProyectosRepository;
            repo.AddInclude("DesafiosProyectos");
            repo.AddInclude("DocumentosProyectos");
            repo.AddInclude("LugaresImplementaciones");
            repo.AddInclude("Tareas");
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
            else if (filters.FechaInicio != null )
            {
                Expression<Func<Proyectos, bool>> query = (e => e.FechaInicio == filters.FechaInicio);
                expressions.Add(query);
            }
            else if (filters.FechaFinal != null)
            {
                Expression<Func<Proyectos, bool>> query = (e => e.FechaFinal == filters.FechaFinal);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.IdTipoBeneficiario))
            {
                Expression<Func<Proyectos, bool>> query = (e => e.IdTipoBeneficiario == filters.IdTipoBeneficiario);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.DatosBeneficiario))
            {
                Expression<Func<Proyectos, bool>> query = (e => e.DatosBeneficiario.ToLower().Contains(filters.DatosBeneficiario.ToLower()));
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.IdTipoPresupuesto))
            {
                Expression<Func<Proyectos, bool>> query = (e => e.IdTipoPresupuesto == filters.IdTipoPresupuesto);
                expressions.Add(query);
            }
            if (!string.IsNullOrEmpty(filters.DescripcionEspecie))
            {
                Expression<Func<Proyectos, bool>> query = (e => e.DescripcionEspecie.ToLower().Contains(filters.DescripcionEspecie.ToLower()));
                expressions.Add(query);
            }

            var data = await _unitOfWork.ProyectosRepository.GetAsync(expressions);
            return data;
        }

        public async Task<Proyectos> AgregarProyecto(Proyectos proyecto)
        {
            proyecto.IdProyecto = 0;
            _unitOfWork.ProyectosRepository.AddNoSave(proyecto);
            await _unitOfWork.SaveChangesAsync();
            return proyecto;
        }

        public async Task<bool> ActualizarProyecto(Proyectos proyecto)
        {
            var Proyecto = await ObtenerProyecto(proyecto.IdProyecto);
            if (Proyecto != null)
            {
                proyecto.CopyTo(Proyecto);
                _unitOfWork.ProyectosRepository.UpdateNoSave(Proyecto);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
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
                _unitOfWork.ProyectosRepository.DeleteNoSave(Proyecto);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}