using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Models;
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
        
        public async Task<Estados> AgregarEstados(Estados estado)
        {
            return await AddAsync(estado);
        }
    }
}
