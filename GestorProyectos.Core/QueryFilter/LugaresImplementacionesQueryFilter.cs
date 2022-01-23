using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.QueryFilter
{
    public partial class LugaresImplementacionesQueryFilter : BaseQueryFilter
    {
        public int IdImplementacion { get; set; }
        public int IdProyecto { get; set; }
        public int IdProvincia { get; set; }
    }
}