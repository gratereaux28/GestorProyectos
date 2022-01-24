namespace GestorProyectos.Core.Models
{
    public partial class Ejecuciones
    {
        public int IdEjecucion { get; set; }
        public int IdProyecto { get; set; }
        public decimal PresupuestoEjecutado { get; set; }
        public int? ProyectoInpactadoId { get; set; }

        public virtual Proyectos Proyecto { get; set; } = null!;
    }
}