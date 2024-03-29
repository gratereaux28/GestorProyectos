﻿namespace GestorProyectos.Core.Models
{
    public partial class TipoBeneficiario
    {
        public TipoBeneficiario()
        {
            TiposBeneficiarioProyectos = new HashSet<TiposBeneficiarioProyecto>();
        }

        public int IdTipo { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<TiposBeneficiarioProyecto> TiposBeneficiarioProyectos { get; set; }
    }
}
