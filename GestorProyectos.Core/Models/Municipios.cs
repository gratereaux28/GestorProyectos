using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class Municipios
    {
        public Municipios()
        {
            DistritosMunicipales = new HashSet<DistritosMunicipales>();
            TerritoriosImpactados = new HashSet<TerritoriosImpactados>();
        }

        public int IdMunicipio { get; set; }
        public int IdProvincia { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public virtual Provincias Provincia { get; set; } = null!;
        public virtual ICollection<DistritosMunicipales> DistritosMunicipales { get; set; }
        public virtual ICollection<TerritoriosImpactados> TerritoriosImpactados { get; set; }
    }
}
