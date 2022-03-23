using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.QueryFilter
{
    public partial class ActividadesQueryFilter
    {
        public int? IdActividad { get; set; }
        public string? Descripcion { get; set; }
        public int? IdProyecto { get; set; }
        public int? Orden { get; set; }
    }
}
