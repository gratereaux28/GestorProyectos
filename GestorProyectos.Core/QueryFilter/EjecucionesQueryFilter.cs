using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.QueryFilter
{
    public partial class EjecucionesQueryFilter : BaseQueryFilter
    {
        public int? IdEjecucion { get; set; }
        public int? IdProyecto { get; set; }
        public decimal? PresupuestoEjecutado { get; set; }
        public int? ProyectoInpactadoId { get; set; }
    }
}