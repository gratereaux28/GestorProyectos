namespace GestorProyectos.Core.Models
{
    public partial class DesafiosProyectos
    {
        public int IdDesafioProyecto { get; set; }
        public int IdProyecto { get; set; }
        public int IdDesafio { get; set; }

        public virtual Desafios Desafio { get; set; } = null!;
        public virtual Proyectos Proyecto { get; set; } = null!;
    }
}