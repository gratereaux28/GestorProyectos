using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorProyectos.Core.DTOs
{
    public class BarriosDto
    {
        public int IdBarrio { get; set; }
        public int IdSeccion { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public int Parcela { get; set; }
    }
}
