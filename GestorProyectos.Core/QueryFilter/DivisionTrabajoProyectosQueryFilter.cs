namespace GestorProyectos.Core.QueryFilter
{
    public class DivisionTrabajoProyectosQueryFilter : BaseQueryFilter
    {
        public int? IdDivision { get; set; }
        public int? IdParticipante { get; set; }
        public int? IdNivelAcceso { get; set; }
        public int? CantidadAsignaciones { get; set; }
    }
}
