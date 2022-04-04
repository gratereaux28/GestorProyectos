using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class DesafiosProyecto
    {
        public int IdDesafioProyecto { get; set; }
        public int IdProyecto { get; set; }
        public int IdDesafio { get; set; }

        public virtual Desafio IdDesafioNavigation { get; set; } = null!;
        public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
    }
}
