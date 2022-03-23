using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.QueryFilter
{
    public partial class TareasQueryFilter : BaseQueryFilter
    {
        public int? IdTarea { get; set; }
        public string? Descripcion { get; set; }
        public int? IdActividad { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int? IdEstado { get; set; }
    }
}