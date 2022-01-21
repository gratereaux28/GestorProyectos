using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorProyectos.Core.DTOs
{
    public class EstadosDto
    {
        public int IdEstado { get; set; }
        public string IdTipo { get; set; }
        public string Nombre { get; set; }
        public int? Orden { get; set; }
    }
}
