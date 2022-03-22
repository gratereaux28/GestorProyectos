namespace GestorProyectos.Core.Models
{
    public partial class TiposBeneficiarioProyecto
    {
        public int IdTipoBeneficiarioProyecto { get; set; }
        public int IdTipo { get; set; }
        public int IdProyecto { get; set; }

        public virtual Proyectos Proyecto { get; set; } = null!;
        public virtual TipoBeneficiario TipoBeneficiario { get; set; } = null!;
    }
}
