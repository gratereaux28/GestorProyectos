using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.DTOs
{
    public partial class DonantesDto
    {
        public int? IdDonante { get; set; }
        public int? IdProyecto { get; set; }
        public string? Nombre { get; set; }
        public string? Identificacion { get; set; }
        public int? IdClasificacion { get; set; }
        public string? Direccion { get; set; }
        public string? Informacion { get; set; }
        public virtual ICollection<DonacionDto> Donaciones { get; set; }
    }
}
