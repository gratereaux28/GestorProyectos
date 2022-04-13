using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class Donantes
    {
        public Donantes()
        {
            Donaciones = new HashSet<Donacion>();
        }

        public int IdDonante { get; set; }
        public int IdProyecto { get; set; }
        public string Nombre { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
        public int IdClasificacion { get; set; }
        public string Direccion { get; set; } = null!;
        public string Informacion { get; set; } = null!;

        public virtual DonantesClasificaciones DonantesClasificacion { get; set; } = null!;
        public virtual Proyectos Proyecto { get; set; } = null!;
        public virtual ICollection<Donacion> Donaciones { get; set; }
    }
}
