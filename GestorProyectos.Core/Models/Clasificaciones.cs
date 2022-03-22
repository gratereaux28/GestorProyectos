namespace GestorProyectos.Core.Models
{
    public partial class Clasificaciones
    {
        public Clasificaciones()
        {
            Aliados = new HashSet<Aliado>();
        }

        public int IdClasificacion { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Aliado> Aliados { get; set; }
    }
}
