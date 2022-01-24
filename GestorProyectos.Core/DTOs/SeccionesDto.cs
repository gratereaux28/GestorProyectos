using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.DTOs
{
    public partial class SeccionesDto
    {
        public int? IdSeccion { get; set; }
        public int IdDistrito { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
    }
}
