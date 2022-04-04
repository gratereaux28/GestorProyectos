using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class AliadoClasificacione
    {
        public AliadoClasificacione()
        {
            Aliados = new HashSet<Aliado>();
        }

        public int IdClasificacion { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Aliado> Aliados { get; set; }
    }
}
