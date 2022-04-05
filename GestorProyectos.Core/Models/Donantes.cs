using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class Donantes
    {
        public int IdDonante { get; set; }
        public int IdProyecto { get; set; }
        public string Nombre { get; set; } = null!;
        public string Identificacion { get; set; } = null!;
        public int IdClasificacion { get; set; }
        public int IdDonacionClasificacion { get; set; }
        public decimal? Monto1 { get; set; }
        public decimal? Monto2 { get; set; }
        public decimal? Donacion { get; set; }
        public string Direccion { get; set; } = null!;
        public string Informacion { get; set; } = null!;

        public virtual DonantesClasificaciones DonantesClasificacion { get; set; } = null!;
        public virtual Proyectos Proyecto { get; set; } = null!;
    }
}
