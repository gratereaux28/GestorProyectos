﻿using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class Proyectos
    {
        public Proyectos()
        {
            DesafiosProyectos = new HashSet<DesafiosProyectos>();
            DocumentosProyectos = new HashSet<DocumentosProyectos>();
            Ejecuciones = new HashSet<Ejecuciones>();
            LugaresImplementaciones = new HashSet<LugaresImplementaciones>();
            Tareas = new HashSet<Tareas>();
            TerritoriosImpactados = new HashSet<TerritoriosImpactados>();
        }

        public int IdProyecto { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string? IdTipoBeneficiario { get; set; }
        public string? DatosBeneficiario { get; set; }
        public string IdTipoPresupuesto { get; set; } = null!;
        public decimal RangoPresupuestado { get; set; }
        public string? DescripcionEspecie { get; set; }

        public virtual ICollection<DesafiosProyectos> DesafiosProyectos { get; set; }
        public virtual ICollection<DocumentosProyectos> DocumentosProyectos { get; set; }
        public virtual ICollection<Ejecuciones> Ejecuciones { get; set; }
        public virtual ICollection<LugaresImplementaciones> LugaresImplementaciones { get; set; }
        public virtual ICollection<Tareas> Tareas { get; set; }
        public virtual ICollection<TerritoriosImpactados> TerritoriosImpactados { get; set; }
    }
}