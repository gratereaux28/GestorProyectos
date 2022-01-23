namespace GestorProyectos.Core.Models
{
    public partial class Estados
    {
        public Estados()
        {
            Tareas = new HashSet<Tareas>();
        }

        public int IdEstado { get; set; }
        public string IdTipo { get; set; }
        public string Nombre { get; set; }
        public int Orden { get; set; }

        public virtual ICollection<Tareas> Tareas { get; set; }
    }
}
