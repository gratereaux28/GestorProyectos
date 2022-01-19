using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Models;
using GestorProyectos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace GestorProyectos.Infrastructure.Repositories
{
    public class BarriosRepository : BaseRepository<Barrios>, IBarriosRepository
    {
        ProyectosDbContext _context;

        public BarriosRepository(ProyectosDbContext context) : base(context)
        {
            _context = context;
        }
        
    }
}
