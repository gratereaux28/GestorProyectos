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
        private readonly IBaseRepository<Barrios> _barriosRepository;
        private readonly IBaseRepository<Beneficiarios> _beneficiariosRepository;
        private readonly IBaseRepository<Desafios> _desafiosRepository;
        private readonly IBaseRepository<DesafiosProyectos> _desafiosProyectosRepository;
        private readonly IBaseRepository<DistritosMunicipales> _distritosMunicipalesRepository;
        private readonly IBaseRepository<DocumentosProyectos> _documentosProyectosRepository;
        private readonly IBaseRepository<Ejecuciones> _ejecucionesRepository;
        private readonly IBaseRepository<Estados> _estadosRepository;
        private readonly IBaseRepository<LugaresImplementaciones> _lugaresImplementacionesRepository;
        private readonly IBaseRepository<Municipios> _municipiosRepository;
        private readonly IBaseRepository<Provincias> _provinciasRepository;
        private readonly IBaseRepository<Proyectos> _proyectosRepository;
        private readonly IBaseRepository<Secciones> _seccionesRepository;
        private readonly IBaseRepository<Tareas> _tareasRepository;
        private readonly IBaseRepository<Usuarios> _usuariosRepository;

        public UnitOfWork(ProyectosDbContext context)
        {
            _context = context;
        }

        public IBaseRepository<Barrios> BarriosRepository => _barriosRepository ?? new BaseRepository<Barrios>(_context);
        public IBaseRepository<Beneficiarios> BeneficiariosRepository => _beneficiariosRepository ?? new BaseRepository<Beneficiarios>(_context);
        public IBaseRepository<Desafios> DesafiosRepository => _desafiosRepository ?? new BaseRepository<Desafios>(_context);
        public IBaseRepository<DesafiosProyectos> DesafiosProyectosRepository => _desafiosProyectosRepository ?? new BaseRepository<DesafiosProyectos>(_context);
        public IBaseRepository<DistritosMunicipales> DistritosMunicipalesRepository => _distritosMunicipalesRepository ?? new BaseRepository<DistritosMunicipales>(_context);
        public IBaseRepository<DocumentosProyectos> DocumentosProyectosRepository => _documentosProyectosRepository ?? new BaseRepository<DocumentosProyectos>(_context);
        public IBaseRepository<Ejecuciones> EjecucionesRepository => _ejecucionesRepository ?? new BaseRepository<Ejecuciones>(_context);
        public IBaseRepository<Estados> EstadosRepository => _estadosRepository ?? new BaseRepository<Estados>(_context);
        public IBaseRepository<LugaresImplementaciones> LugaresImplementacionesRepository => _lugaresImplementacionesRepository ?? new BaseRepository<LugaresImplementaciones>(_context);
        public IBaseRepository<Municipios> MunicipiosRepository => _municipiosRepository ?? new BaseRepository<Municipios>(_context);
        public IBaseRepository<Provincias> ProvinciasRepository => _provinciasRepository ?? new BaseRepository<Provincias>(_context);
        public IBaseRepository<Proyectos> ProyectosRepository => _proyectosRepository ?? new BaseRepository<Proyectos>(_context);
        public IBaseRepository<Secciones> SeccionesRepository => _seccionesRepository ?? new BaseRepository<Secciones>(_context);
        public IBaseRepository<Tareas> TareasRepository => _tareasRepository ?? new BaseRepository<Tareas>(_context);
        public IBaseRepository<Usuarios> UsuariosRepository => _usuariosRepository ?? new BaseRepository<Usuarios>(_context);

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

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public async Task BeginTransactionAsync()
        {
            await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _context.Database.CommitTransactionAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _context.Database.RollbackTransactionAsync();
        }
    }
}