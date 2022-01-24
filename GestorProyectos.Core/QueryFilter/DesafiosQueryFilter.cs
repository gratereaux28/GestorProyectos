using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.QueryFilter
{
    public partial class DesafiosQueryFilter: BaseQueryFilter
    {
        public int? IdDesafio { get; set; }
        public string? Nombre { get; set; }
    }
}