using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using GestorProyectos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestorProyectos.Infrastructure.Repositories
{
    public class EstadosRepository : BaseRepository<Estados>, IEstadosRepository
    {
        public EstadosRepository(ProyectosDbContext context) : base(context) {}

        public async Task<IEnumerable<Estados>> ObtenerEstados(EstadosQueryFilter filters)
        {
            var query = GetQAsync();

            if (filters.IdEstado != null)
                query = query.Where(e => e.IdEstado == filters.IdEstado);
            if (filters.Nombre != null)
                query = query.Where(e => e.Nombre.ToLower().Contains(filters.Nombre.ToLower()));
            if (filters.IdTipo != null)
                query = query.Where(e => e.IdTipo == filters.IdTipo);

            var Estados = await query.ToListAsync();
            return Estados;
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
