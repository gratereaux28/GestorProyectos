using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.DTOs
{
    public partial class LugaresImplementacionesDto
    {
        public int? IdImplementacion { get; set; }
        public int IdProyecto { get; set; }
        public int IdProvincia { get; set; }
    }
}