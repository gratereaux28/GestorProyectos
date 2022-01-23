using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.DTOs
{
    public partial class EjecucionesDto
    {
        public int IdEjecucion { get; set; }
        public int IdProyecto { get; set; }
        public decimal PresupuestoEjecutado { get; set; }
        public int? ProyectoInpactadoId { get; set; }

        public virtual ProyectosDto Proyecto { get; set; } = null!;
    }
}