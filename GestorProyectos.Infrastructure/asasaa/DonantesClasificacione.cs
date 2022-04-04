using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class DonantesClasificacione
    {
        public DonantesClasificacione()
        {
            Donantes = new HashSet<Donante>();
        }

        public int IdClasificacion { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Donante> Donantes { get; set; }
    }
}
