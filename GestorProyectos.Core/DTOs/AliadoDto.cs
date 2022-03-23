namespace GestorProyectos.Core.DTOs
{
    public partial class AliadoDto
    {
        public int IdAliado { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Identificacion { get; set; }
        public int IdClasificacion { get; set; }
        public string? Direccion { get; set; }
        public string? Informacion { get; set; }
    }
}
