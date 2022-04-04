using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class DistritosMunicipale
    {
        public DistritosMunicipale()
        {
            LugaresImplementaciones = new HashSet<LugaresImplementacione>();
            Secciones = new HashSet<Seccione>();
        }

        public int IdDistrito { get; set; }
        public int IdMunicipio { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public virtual Municipio IdMunicipioNavigation { get; set; } = null!;
        public virtual ICollection<LugaresImplementacione> LugaresImplementaciones { get; set; }
        public virtual ICollection<Seccione> Secciones { get; set; }
    }
}
