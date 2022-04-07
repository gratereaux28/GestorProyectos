using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.DTOs
{
    public partial class LugaresImplementacionesDto
    {
        public int? IdImplementacion { get; set; }
        public int? IdProyecto { get; set; }
        public int? IdProvincia { get; set; }
        public int? IdMunicipio { get; set; }
        public int? IdDistrito { get; set; }
        public int? IdSeccion { get; set; }
        public int? IdBarrio { get; set; }
    }
}