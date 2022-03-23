﻿using GestorProyectos.Base.Interfaces;
using GestorProyectos.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorProyectos.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IBaseRepository<Actividades> ActividadesRepository { get; }
        public IBaseRepository<Aliado> AliadoRepository { get; }
        public IBaseRepository<AliadoClasificaciones> AliadoClasificacionesRepository { get; }
        public IBaseRepository<Barrios> BarriosRepository { get; }
        public IBaseRepository<Beneficiarios> BeneficiariosRepository { get; }
        public IBaseRepository<Desafios> DesafiosRepository { get; }
        public IBaseRepository<DesafiosProyectos> DesafiosProyectosRepository { get; }
        public IBaseRepository<DistritosMunicipales> DistritosMunicipalesRepository { get; }
        public IBaseRepository<DivisionTrabajoProyectos> DivisionTrabajoProyectosRepository { get; }
        public IBaseRepository<DocumentosProyectos> DocumentosProyectosRepository { get; }
        public IBaseRepository<Ejecuciones> EjecucionesRepository { get; }
        public IBaseRepository<Estados> EstadosRepository { get; }
        public IBaseRepository<LugaresImplementaciones> LugaresImplementacionesRepository { get; }
        public IBaseRepository<Municipios> MunicipiosRepository { get; }
        public IBaseRepository<NivelAcceso> NivelAccesoRepository { get; }
        public IBaseRepository<Provincias> ProvinciasRepository { get; }
        public IBaseRepository<Proyectos> ProyectosRepository { get; }
        public IBaseRepository<RangoBeneficiarios> RangoBeneficiariosRepository { get; }
        public IBaseRepository<Secciones> SeccionesRepository { get; }
        public IBaseRepository<Tareas> TareasRepository { get; }
        public IBaseRepository<TipoBeneficiario> TipoBeneficiarioRepository { get; }
        public IBaseRepository<TiposBeneficiarioProyecto> TiposBeneficiarioProyectoRepository { get; }
        public IBaseRepository<Usuarios> UsuariosRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();

    }
}