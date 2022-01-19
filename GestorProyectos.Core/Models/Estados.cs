using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class Estados
    {
        public int IdEstado { get; set; }
        public string IdTipo { get; set; }
        public string Nombre { get; set; }
        public int Orden { get; set; }
    }
}
