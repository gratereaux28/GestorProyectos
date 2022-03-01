namespace GestorProyectos.Core.Models
{
    public partial class Tareas
    {
        public Tareas()
        {
            DocumentosProyectos = new HashSet<DocumentosProyectos>();
        }

        public int IdTarea { get; set; }
        public string Descripcion { get; set; }
        public int IdProyecto { get; set; }
        public int? IdResponsable { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int IdEstado { get; set; }
        public string FechaCreacion { get; set; }

        public virtual Estados Estado { get; set; } = null!;
        public virtual Proyectos Proyecto { get; set; } = null!;
        public virtual Usuarios Responsable { get; set; }
        public virtual ICollection<DocumentosProyectos> DocumentosProyectos { get; set; }
    }
}