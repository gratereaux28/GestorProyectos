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
        public int IdActividad { get; set; }
        public int? IdResponsable { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int IdEstado { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Estados Estado { get; set; } = null!;
        public virtual Usuarios? Usuario { get; set; }
        public virtual Actividades Actividad { get; set; }
        public virtual ICollection<DocumentosProyectos> DocumentosProyectos { get; set; }
    }
}