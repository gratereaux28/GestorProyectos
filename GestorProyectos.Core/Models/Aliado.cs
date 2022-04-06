namespace GestorProyectos.Core.Models
{
    public partial class Aliado
    {
        public int IdAliado { get; set; }
        public int IdProyecto { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Identificacion { get; set; }
        public int IdClasificacion { get; set; }
        public string? Direccion { get; set; }
        public string? Informacion { get; set; }

        public virtual AliadoClasificaciones Clasificacion { get; set; } = null!;
        public virtual Proyectos Proyecto { get; set; }
    }
}
