using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.DTOs
{
    public partial class DonacionDto
    {
        public int IdDonacion { get; set; }
        public int IdDonante { get; set; }
        public int IdClasificacion { get; set; }
        public decimal MontoDOP { get; set; }
        public decimal MontoUSD { get; set; }
        public string Descripcion { get; set; } = null!;
    }
}
