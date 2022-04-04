using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class Barrio
    {
        public Barrio()
        {
            LugaresImplementaciones = new HashSet<LugaresImplementacione>();
        }

        public int IdBarrio { get; set; }
        public int IdSeccion { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public int Parcela { get; set; }

        public virtual Seccione IdSeccionNavigation { get; set; } = null!;
        public virtual ICollection<LugaresImplementacione> LugaresImplementaciones { get; set; }
    }
}
