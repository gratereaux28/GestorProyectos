using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class DonacionClasificaciones
    {
        public DonacionClasificaciones()
        {
            Donaciones = new HashSet<Donacion>();
        }

        public int IdClasificacion { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Donacion> Donaciones { get; set; }
    }
}
