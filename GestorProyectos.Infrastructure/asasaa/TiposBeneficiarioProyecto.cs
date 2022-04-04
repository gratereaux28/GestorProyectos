using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class TiposBeneficiarioProyecto
    {
        public int IdTipoBeneficiarioProyecto { get; set; }
        public int IdTipo { get; set; }
        public int IdProyecto { get; set; }

        public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
        public virtual TipoBeneficiario IdTipoNavigation { get; set; } = null!;
    }
}
