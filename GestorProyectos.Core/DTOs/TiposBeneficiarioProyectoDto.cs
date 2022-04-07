namespace GestorProyectos.Core.DTOs
{
    public partial class TiposBeneficiarioProyectoDto
    {
        public int? IdTipoBeneficiarioProyecto { get; set; }
        public int? IdTipo { get; set; }
        public int? IdProyecto { get; set; }
        public string? Nombre { get; set; }
    }
}