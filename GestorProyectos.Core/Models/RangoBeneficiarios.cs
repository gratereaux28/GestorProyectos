using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class RangoBeneficiarios
    {
        public RangoBeneficiarios()
        {
            Proyectos = new HashSet<Proyectos>();
        }

        public int IdRango { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Proyectos> Proyectos { get; set; }
    }
}
