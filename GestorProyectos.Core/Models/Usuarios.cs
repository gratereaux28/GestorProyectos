namespace GestorProyectos.Core.Models
{
    public class Usuarios
    {
        public Usuarios()
        {
            Tareas = new HashSet<Tareas>();
        }

        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public virtual ICollection<Tareas> Tareas { get; set; }
    }
}