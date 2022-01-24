using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.QueryFilter
{
    public partial class ProyectosQueryFilter : BaseQueryFilter
    {
        public int? IdProyecto { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public string? IdTipoBeneficiario { get; set; }
        public string? DatosBeneficiario { get; set; }
        public string? IdTipoPresupuesto { get; set; }
        public decimal? RangoPresupuestado { get; set; }
        public string? DescripcionEspecie { get; set; }
    }
}