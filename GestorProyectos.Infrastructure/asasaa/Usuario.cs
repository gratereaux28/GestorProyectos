using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class Usuario
    {
        public Usuario()
        {
            Tareas = new HashSet<Tarea>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string Usuario1 { get; set; } = null!;
        public string Clave { get; set; } = null!;

        public virtual ICollection<Tarea> Tareas { get; set; }
    }
}
