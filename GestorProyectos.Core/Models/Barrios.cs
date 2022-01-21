using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class Barrios: BaseModel
    {
        public int IdBarrio { get; set; }
        public int IdSeccion { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public int Parcela { get; set; }

        public virtual Secciones Secciones { get; set; } = null!;
    }
}
