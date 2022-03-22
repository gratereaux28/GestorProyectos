namespace GestorProyectos.Core.Models
{
    public partial class Secciones
    {
        public Secciones()
        {
            Barrios = new HashSet<Barrios>();
            LugaresImplementaciones = new HashSet<LugaresImplementaciones>();
        }

        public int IdSeccion { get; set; }
        public int IdDistrito { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public virtual DistritosMunicipales DistritosMunicipal { get; set; } = null!;
        public virtual ICollection<Barrios> Barrios { get; set; }
        public virtual ICollection<LugaresImplementaciones> LugaresImplementaciones { get; set; }
    }
}
