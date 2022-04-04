using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class DonantesClasificaciones
    {
        public DonantesClasificaciones()
        {
            Donantes = new HashSet<Donantes>();
        }

        public int IdClasificacion { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Donantes> Donantes { get; set; }
    }
}
