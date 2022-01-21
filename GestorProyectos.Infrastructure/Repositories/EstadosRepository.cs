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
        ProyectosDbContext _context;

        public EstadosRepository(ProyectosDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Estados> ObtenerEstado(int IdEstado)
        {
            var Estado = await GetAsync(e => e.IdEstado == IdEstado);
            return Estado.FirstOrDefault();
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
