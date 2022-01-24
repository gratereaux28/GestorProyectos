using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.QueryFilter
{
    public partial class SeccionesQueryFilter : BaseQueryFilter
    {
        public int? IdSeccion { get; set; }
        public int? IdDistrito { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
    }
}
