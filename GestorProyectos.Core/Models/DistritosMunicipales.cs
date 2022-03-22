namespace GestorProyectos.Core.Models
{
    public partial class DistritosMunicipales
    {
        public DistritosMunicipales()
        {
            LugaresImplementaciones = new HashSet<LugaresImplementaciones>();
            Secciones = new HashSet<Secciones>();
        }

        public int IdDistrito { get; set; }
        public int IdMunicipio { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public virtual Municipios Municipio { get; set; } = null!;
        public virtual ICollection<LugaresImplementaciones> LugaresImplementaciones { get; set; }
        public virtual ICollection<Secciones> Secciones { get; set; }
    }
}