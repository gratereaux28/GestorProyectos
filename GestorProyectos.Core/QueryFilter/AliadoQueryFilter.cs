namespace GestorProyectos.Core.QueryFilter
{
    public class AliadoQueryFilter : BaseQueryFilter
    {
        public int? IdAliado { get; set; }
        public string? Nombre { get; set; }
        public string? Identificacion { get; set; }
        public int? IdClasificacion { get; set; }
        public string? Direccion { get; set; }
        public string? Informacion { get; set; }
    }
}
