namespace GestorProyectos.Core.QueryFilter
{
    public class AliadoClasificacionesQueryFilter : BaseQueryFilter
    {
        public int? IdClasificacion { get; set; }
        public string? Nombre { get; set; } = null!;
    }
}
