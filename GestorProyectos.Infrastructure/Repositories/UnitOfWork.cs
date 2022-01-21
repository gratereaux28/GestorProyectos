using GestorProyectos.Base.Implementations;
using GestorProyectos.Base.Interfaces;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Models;
using GestorProyectos.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorProyectos.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProyectosDbContext _context;
        private readonly IBaseRepository<Estados> _estadosRepository;

        public UnitOfWork(ProyectosDbContext context)
        {
            _context = context;
        }

        public IBaseRepository<Estados> EstadosRepository => _estadosRepository ?? new BaseRepository<Estados>(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
