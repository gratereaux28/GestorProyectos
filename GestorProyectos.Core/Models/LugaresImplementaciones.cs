using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class LugaresImplementaciones
    {
        public int IdImplementacion { get; set; }
        public int IdProyecto { get; set; }
        public int IdProvincia { get; set; }

        public virtual Provincias Provincia { get; set; } = null!;
        public virtual Proyectos Proyecto { get; set; } = null!;
    }
}