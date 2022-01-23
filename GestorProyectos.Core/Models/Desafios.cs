using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class Desafios
    {
        public Desafios()
        {
            DesafiosProyectos = new HashSet<DesafiosProyectos>();
        }

        public int IdDesafio { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<DesafiosProyectos> DesafiosProyectos { get; set; }
    }
}