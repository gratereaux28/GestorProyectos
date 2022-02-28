namespace GestorProyectos.Core.DTOs
{
    public partial class TerritoriosImpactadosDto
    {
        public int? IdImpacto { get; set; }
        public int IdProyecto { get; set; }
        public int? IdMunicipio { get; set; }
        public int? IdBarrio { get; set; }

        public virtual BarriosDto Barrio { get; set; }
        public virtual MunicipiosDto Municipio { get; set; }
    }
}