using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class Ejecucione
    {
        public int IdEjecucion { get; set; }
        public int IdProyecto { get; set; }
        public decimal PresupuestoEjecutado { get; set; }
        public int? ProyectoInpactadoId { get; set; }

        public virtual Proyecto IdProyectoNavigation { get; set; } = null!;
    }
}
