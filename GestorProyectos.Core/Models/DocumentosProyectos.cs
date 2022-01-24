namespace GestorProyectos.Core.Models
{
    public partial class DocumentosProyectos
    {
        public int IdDocumento { get; set; }
        public int IdProyecto { get; set; }
        public int? IdTarea { get; set; }
        public byte[] Contenido { get; set; } = null!;
        public DateTime Fecha { get; set; }
        public string NombreArchivo { get; set; } = null!;
        public string Ext { get; set; } = null!;
        public string? Url { get; set; }

        public virtual Proyectos Proyecto { get; set; } = null!;
        public virtual Tareas Tarea { get; set; }
    }
}