using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.QueryFilter
{
    public partial class DesafiosProyectosQueryFilter : BaseQueryFilter
    {
        public int IdDesafioProyecto { get; set; }
        public int IdProyecto { get; set; }
        public int IdDesafio { get; set; }
    }
}