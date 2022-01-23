namespace GestorProyectos.Core.QueryFilter
{
    public class BarriosQueryFilter : BaseQueryFilter
    {
        public int? IdBarrio { get; set; }
        public int? IdSeccion { get; set; }
        public string? Nombre { get; set; }
        public int? Parcela { get; set; }
    }
}
