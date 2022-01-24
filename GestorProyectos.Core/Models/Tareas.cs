namespace GestorProyectos.Core.Models
{
    public partial class Tareas
    {
        public Tareas()
        {
            DocumentosProyectos = new HashSet<DocumentosProyectos>();
        }

        public int IdTarea { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdProyecto { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int IdEstado { get; set; }

        public virtual Estados Estado { get; set; } = null!;
        public virtual Proyectos Proyecto { get; set; } = null!;
        public virtual ICollection<DocumentosProyectos> DocumentosProyectos { get; set; }
    }
}