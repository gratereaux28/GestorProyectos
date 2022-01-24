namespace GestorProyectos.Core.Models
{
    public partial class TerritoriosImpactados
    {
        public int IdImpacto { get; set; }
        public int IdProyecto { get; set; }
        public int? IdMunicipio { get; set; }
        public int? IdBarrio { get; set; }

        public virtual Barrios Barrio { get; set; }
        public virtual Municipios Municipio { get; set; }
        public virtual Proyectos Proyecto { get; set; } = null!;
    }
}