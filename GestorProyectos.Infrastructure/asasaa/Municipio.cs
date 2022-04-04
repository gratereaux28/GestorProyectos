using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class Municipio
    {
        public Municipio()
        {
            DistritosMunicipales = new HashSet<DistritosMunicipale>();
            LugaresImplementaciones = new HashSet<LugaresImplementacione>();
        }

        public int IdMunicipio { get; set; }
        public int IdProvincia { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public virtual Provincia IdProvinciaNavigation { get; set; } = null!;
        public virtual ICollection<DistritosMunicipale> DistritosMunicipales { get; set; }
        public virtual ICollection<LugaresImplementacione> LugaresImplementaciones { get; set; }
    }
}
