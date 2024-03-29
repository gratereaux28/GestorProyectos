﻿using GestorProyectos.Base.Implementations;
using GestorProyectos.Base.Interfaces;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Models;
using GestorProyectos.Infrastructure.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace GestorProyectos.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProyectosDbContext _context;
        private readonly IBaseRepository<Actividades> _actividadesRepository;
        private readonly IBaseRepository<Aliado> _aliadoRepository;
        private readonly IBaseRepository<AliadoClasificaciones> _aliadoClasificacionesRepository;
        private readonly IBaseRepository<Barrios> _barriosRepository;
        private readonly IBaseRepository<Beneficiarios> _beneficiariosRepository;
        private readonly IBaseRepository<Desafios> _desafiosRepository;
        private readonly IBaseRepository<DesafiosProyectos> _desafiosProyectosRepository;
        private readonly IBaseRepository<DistritosMunicipales> _distritosMunicipalesRepository;
        private readonly IBaseRepository<DivisionTrabajoProyectos> _divisionTrabajoProyectosRepository;
        private readonly IBaseRepository<DocumentosProyectos> _documentosProyectosRepository;
        private readonly IBaseRepository<Donacion> _donacionRepository;
        private readonly IBaseRepository<DonacionClasificaciones> _donacionClasificacionesRepository;
        private readonly IBaseRepository<Donantes> _donantesRepository;
        private readonly IBaseRepository<DonantesClasificaciones> _donantesClasificacionesRepository;
        private readonly IBaseRepository<Ejecuciones> _ejecucionesRepository;
        private readonly IBaseRepository<Estados> _estadosRepository;
        private readonly IBaseRepository<LugaresImplementaciones> _lugaresImplementacionesRepository;
        private readonly IBaseRepository<Municipios> _municipiosRepository;
        private readonly IBaseRepository<NivelAcceso> _nivelAccesoRepository;
        private readonly IBaseRepository<Provincias> _provinciasRepository;
        private readonly IBaseRepository<Proyectos> _proyectosRepository;
        private readonly IBaseRepository<RangoBeneficiarios> _rangoBeneficiariosRepository;
        private readonly IBaseRepository<RangoPresupuestario> _rangoPresupuestarioRepository;
        private readonly IBaseRepository<Secciones> _seccionesRepository;
        private readonly IBaseRepository<Tareas> _tareasRepository;
        private readonly IBaseRepository<TipoBeneficiario> _tipoBeneficiarioRepository;
        private readonly IBaseRepository<TiposBeneficiarioProyecto> _tiposBeneficiarioProyectoRepository;
        private readonly IBaseRepository<Usuarios> _usuariosRepository;

        public IOlvidoClaveRepository _olvidoClaveRepository;


        public IConfiguration Configuration { get; }
        public UnitOfWork(ProyectosDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public IBaseRepository<Actividades> ActividadesRepository => _actividadesRepository ?? new BaseRepository<Actividades>(_context);
        public IBaseRepository<Aliado> AliadoRepository => _aliadoRepository ?? new BaseRepository<Aliado>(_context);
        public IBaseRepository<AliadoClasificaciones> AliadoClasificacionesRepository => _aliadoClasificacionesRepository ?? new BaseRepository<AliadoClasificaciones>(_context);
        public IBaseRepository<Barrios> BarriosRepository => _barriosRepository ?? new BaseRepository<Barrios>(_context);
        public IBaseRepository<Beneficiarios> BeneficiariosRepository => _beneficiariosRepository ?? new BaseRepository<Beneficiarios>(_context);
        public IBaseRepository<Desafios> DesafiosRepository => _desafiosRepository ?? new BaseRepository<Desafios>(_context);
        public IBaseRepository<DesafiosProyectos> DesafiosProyectosRepository => _desafiosProyectosRepository ?? new BaseRepository<DesafiosProyectos>(_context);
        public IBaseRepository<DistritosMunicipales> DistritosMunicipalesRepository => _distritosMunicipalesRepository ?? new BaseRepository<DistritosMunicipales>(_context);
        public IBaseRepository<DivisionTrabajoProyectos> DivisionTrabajoProyectosRepository => _divisionTrabajoProyectosRepository ?? new BaseRepository<DivisionTrabajoProyectos>(_context);
        public IBaseRepository<DocumentosProyectos> DocumentosProyectosRepository => _documentosProyectosRepository ?? new BaseRepository<DocumentosProyectos>(_context);
        public IBaseRepository<Donacion> DonacionRepository => _donacionRepository ?? new BaseRepository<Donacion>(_context);
        public IBaseRepository<DonacionClasificaciones> DonacionClasificacionesRepository => _donacionClasificacionesRepository ?? new BaseRepository<DonacionClasificaciones>(_context);
        public IBaseRepository<Donantes> DonantesRepository => _donantesRepository ?? new BaseRepository<Donantes>(_context);
        public IBaseRepository<DonantesClasificaciones> DonantesClasificacionesRepository => _donantesClasificacionesRepository ?? new BaseRepository<DonantesClasificaciones>(_context);
        public IBaseRepository<Ejecuciones> EjecucionesRepository => _ejecucionesRepository ?? new BaseRepository<Ejecuciones>(_context);
        public IBaseRepository<Estados> EstadosRepository => _estadosRepository ?? new BaseRepository<Estados>(_context);
        public IBaseRepository<LugaresImplementaciones> LugaresImplementacionesRepository => _lugaresImplementacionesRepository ?? new BaseRepository<LugaresImplementaciones>(_context);
        public IBaseRepository<Municipios> MunicipiosRepository => _municipiosRepository ?? new BaseRepository<Municipios>(_context);
        public IBaseRepository<NivelAcceso> NivelAccesoRepository => _nivelAccesoRepository ?? new BaseRepository<NivelAcceso>(_context);
        public IBaseRepository<Provincias> ProvinciasRepository => _provinciasRepository ?? new BaseRepository<Provincias>(_context);
        public IBaseRepository<Proyectos> ProyectosRepository => _proyectosRepository ?? new BaseRepository<Proyectos>(_context);
        public IBaseRepository<RangoBeneficiarios> RangoBeneficiariosRepository => _rangoBeneficiariosRepository ?? new BaseRepository<RangoBeneficiarios>(_context);
        public IBaseRepository<RangoPresupuestario> RangoPresupuestarioRepository => _rangoPresupuestarioRepository ?? new BaseRepository<RangoPresupuestario>(_context);
        public IBaseRepository<Secciones> SeccionesRepository => _seccionesRepository ?? new BaseRepository<Secciones>(_context);
        public IBaseRepository<Tareas> TareasRepository => _tareasRepository ?? new BaseRepository<Tareas>(_context);
        public IBaseRepository<TipoBeneficiario> TipoBeneficiarioRepository => _tipoBeneficiarioRepository ?? new BaseRepository<TipoBeneficiario>(_context);
        public IBaseRepository<TiposBeneficiarioProyecto> TiposBeneficiarioProyectoRepository => _tiposBeneficiarioProyectoRepository ?? new BaseRepository<TiposBeneficiarioProyecto>(_context);
        public IBaseRepository<Usuarios> UsuariosRepository => _usuariosRepository ?? new BaseRepository<Usuarios>(_context);

        public IOlvidoClaveRepository OlvidoClaveRepository => _olvidoClaveRepository ?? new OlvidoClaveRepository(_context, this);

        public DataTable GetDataFromProcedure(string procedure, SqlParameter[]? parametros = null)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("ProyectosDbContext")))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(procedure, conn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();

                return ds.Tables[0];
            }
        }

        public void ExecuteProcedure(string procedure, SqlParameter[]? parametros = null)
        {
            using (SqlConnection conn = new SqlConnection(Configuration.GetConnectionString("ProyectosDbContext")))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(procedure, conn);
                cmd.CommandTimeout = 0;
                cmd.CommandType = CommandType.StoredProcedure;
                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                conn.Close();
            }
        }

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