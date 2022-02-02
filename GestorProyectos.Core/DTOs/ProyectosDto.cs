using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.DTOs
{
    public partial class ProyectosDto
    {
        public int? IdProyecto { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string? IdTipoBeneficiario { get; set; }
        public string? DatosBeneficiario { get; set; }
        public string IdTipoPresupuesto { get; set; } = null!;
        public decimal RangoPresupuestado { get; set; }
        public string? DescripcionEspecie { get; set; }

        public virtual ICollection<DesafiosProyectosDto>? DesafiosProyectos { get; set; }
        public virtual ICollection<DocumentosProyectosDto>? DocumentosProyectos { get; set; }
        public virtual ICollection<LugaresImplementacionesDto>? LugaresImplementaciones { get; set; }
        public virtual ICollection<TareasDto>? Tareas { get; set; }
        public virtual ICollection<TerritoriosImpactadosDto>? TerritoriosImpactados { get; set; }
    }
}