using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class Donacion
    {
        public int IdDonacion { get; set; }
        public int IdDonante { get; set; }
        public int IdClasificacion { get; set; }
        public decimal MontoDOP { get; set; }
        public decimal MontoUSD { get; set; }
        public string Descripcion { get; set; } = null!;

        public virtual DonacionClasificaciones DonacionClasificacion { get; set; } = null!;
        public virtual Donantes Donante { get; set; } = null!;
    }
}
