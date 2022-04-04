using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class Seccione
    {
        public Seccione()
        {
            Barrios = new HashSet<Barrio>();
            LugaresImplementaciones = new HashSet<LugaresImplementacione>();
        }

        public int IdSeccion { get; set; }
        public int IdDistrito { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public virtual DistritosMunicipale IdDistritoNavigation { get; set; } = null!;
        public virtual ICollection<Barrio> Barrios { get; set; }
        public virtual ICollection<LugaresImplementacione> LugaresImplementaciones { get; set; }
    }
}
