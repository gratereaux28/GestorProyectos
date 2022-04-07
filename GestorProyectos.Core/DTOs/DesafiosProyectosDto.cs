using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.DTOs
{
    public partial class DesafiosProyectosDto
    {
        public int? IdDesafioProyecto { get; set; }
        public int? IdProyecto { get; set; }
        public int? IdDesafio { get; set; }
        public string? Nombre { get; set; }
    }
}