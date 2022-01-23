using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.DTOs
{
    public partial class DesafiosDto
    {
        public int IdDesafio { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<DesafiosProyectosDto> DesafiosProyectos { get; set; }
    }
}