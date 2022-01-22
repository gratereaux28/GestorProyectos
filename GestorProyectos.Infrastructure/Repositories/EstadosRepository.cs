using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.CustomModels;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using GestorProyectos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace GestorProyectos.Infrastructure.Repositories
{
    public class EstadosRepository : BaseRepository<Estados>, IEstadosRepository
    {
        public EstadosRepository(ProyectosDbContext context) : base(context) {}

        public async Task<PagedList<Estados>> ObtenerEstados(EstadosQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdEstado != null)
            {
                Expression<Func<Estados, bool>> query = (e => e.IdEstado == filters.IdEstado);
                expressions.Add(query);
            }
            if (filters.Nombre != null)
            {
                Expression<Func<Estados, bool>> query = (e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
                expressions.Add(query);
            }
            if (filters.IdTipo != null)
            {
                Expression<Func<Estados, bool>> query = (e => e.IdTipo == filters.IdTipo);
                expressions.Add(query);
            }

            var data = GetQAsync(expressions);
            var Estados = await data.ToListAsync();

            var pagedEstados = PagedList<Estados>.Create(Estados, filters.pageNumber, filters.pageSize);
            return pagedEstados;
        }

        public async Task<Estados> ObtenerEstado(int IdEstado)
        {
            var query = GetQAsync(e => e.IdEstado == IdEstado);
            var Estado = await query.FirstOrDefaultAsync();
            return Estado;
        }

        public async Task<Estados> AgregarEstado(Estados estado)
        {
            return await AddAsync(estado);
        }

        public async Task<bool> ActualizarEstado(Estados estado)
        {
            var Estado = await ObtenerEstado(estado.IdEstado);
            if (Estado != null) estado.CopyTo(Estado);
            return await UpdateAsync(Estado);
        }

        public async Task<bool> EliminarEstado(int IdEstado)
        {
            var Estado = await ObtenerEstado(IdEstado);
            return await DeleteAsync(Estado);
        }
    }
}
