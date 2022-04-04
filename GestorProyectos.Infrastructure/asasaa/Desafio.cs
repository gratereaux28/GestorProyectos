using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class Desafio
    {
        public Desafio()
        {
            DesafiosProyectos = new HashSet<DesafiosProyecto>();
        }

        public int IdDesafio { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<DesafiosProyecto> DesafiosProyectos { get; set; }
    }
}
