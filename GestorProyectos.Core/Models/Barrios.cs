using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class Barrios
    {
        public Barrios()
        {
            TerritoriosImpactados = new HashSet<TerritoriosImpactados>();
        }

        public int IdBarrio { get; set; }
        public int IdSeccion { get; set; }
        public string Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public int Parcela { get; set; }

        public virtual Secciones Seccion { get; set; } = null!;
        public virtual ICollection<TerritoriosImpactados> TerritoriosImpactados { get; set; }
    }
}
