using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class Provincia
    {
        public Provincia()
        {
            LugaresImplementaciones = new HashSet<LugaresImplementacione>();
            Municipios = new HashSet<Municipio>();
        }

        public int IdProvincia { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public virtual ICollection<LugaresImplementacione> LugaresImplementaciones { get; set; }
        public virtual ICollection<Municipio> Municipios { get; set; }
    }
}
