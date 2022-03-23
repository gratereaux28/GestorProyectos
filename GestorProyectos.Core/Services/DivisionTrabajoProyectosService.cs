using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class DivisionTrabajoProyectosService : IDivisionTrabajoProyectosService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DivisionTrabajoProyectosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<DivisionTrabajoProyectos> ObtenerDivision(int IdDivision)
        {
            var query = await _unitOfWork.DivisionTrabajoProyectosRepository.GetAsync(e => e.IdDivision == IdDivision);
            var Division = query.FirstOrDefault();
            return Division;
        }

        public async Task<IEnumerable<DivisionTrabajoProyectos>> ObtenerDivisionTrabajoProyectos(DivisionTrabajoProyectosQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdDivision != null && filters.IdDivision != 0)
            {
                Expression<Func<DivisionTrabajoProyectos, bool>> query = (e => e.IdDivision == filters.IdDivision);
                expressions.Add(query);
            }

            var data = await _unitOfWork.DivisionTrabajoProyectosRepository.GetAsync(expressions);
            return data;
        }

        public async Task<DivisionTrabajoProyectos> AgregarDivision(DivisionTrabajoProyectos Division)
        {
            Division.IdDivision = 0;
            return await _unitOfWork.DivisionTrabajoProyectosRepository.AddAsync(Division);
        }

        public async Task<bool> ActualizarDivision(DivisionTrabajoProyectos division)
        {
            var Division = await ObtenerDivision(division.IdDivision);
            if (Division != null)
            {
                division.CopyTo(Division);
                _unitOfWork.DivisionTrabajoProyectosRepository.UpdateNoSave(Division);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> EliminarDivision(int IdDivision)
        {
            var Division = await ObtenerDivision(IdDivision);
            if (Division != null)
            {
                _unitOfWork.DivisionTrabajoProyectosRepository.DeleteNoSave(Division);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}