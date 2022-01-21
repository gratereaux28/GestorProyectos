using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Models;
using GestorProyectos.Extensions.sys;
using GestorProyectos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestorProyectos.Infrastructure.Repositories
{
    public class EstadosRepository : BaseRepository<Estados>, IEstadosRepository
    {
        public EstadosRepository(ProyectosDbContext context) : base(context) {}

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
