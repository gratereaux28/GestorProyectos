using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class RangoBeneficiario
    {
        public RangoBeneficiario()
        {
            Proyectos = new HashSet<Proyecto>();
        }

        public int IdRango { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Proyecto> Proyectos { get; set; }
    }
}
