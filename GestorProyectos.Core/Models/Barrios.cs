namespace GestorProyectos.Core.Models
{
    public partial class Barrios
    {
        public Barrios()
        {
            LugaresImplementaciones = new HashSet<LugaresImplementaciones>();
        }

        public int IdBarrio { get; set; }
        public int IdSeccion { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public int Parcela { get; set; }

        public virtual Secciones Seccion { get; set; } = null!;
        public virtual ICollection<LugaresImplementaciones> LugaresImplementaciones { get; set; }
    }
}
