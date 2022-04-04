using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class Aliado
    {
        public Aliado()
        {
            Proyectos = new HashSet<Proyecto>();
        }

        public int IdAliado { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Identificacion { get; set; }
        public int IdClasificacion { get; set; }
        public string? Direccion { get; set; }
        public string? Informacion { get; set; }

        public virtual AliadoClasificacione IdClasificacionNavigation { get; set; } = null!;
        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
