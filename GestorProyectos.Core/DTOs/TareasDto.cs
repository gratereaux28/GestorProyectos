using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.DTOs
{
    public partial class TareasDto
    {
        public int? IdTarea { get; set; }
        public string? Descripcion { get; set; }
        public int? IdActividad { get; set; }
        public int? Meta { get; set; }
        public string? Periodo { get; set; }
        public int? Meses { get; set; }
        public int? Dias { get; set; }
        public decimal? MontoPresupuestarioDOP { get; set; }
        public decimal? MontoPresupuestarioUSD { get; set; }
        public string? Resultado { get; set; }
        public string? PosiblesRiesgos { get; set; }
        public string? AccionMitigacion { get; set; }
        public int? IdResponsable { get; set; }
        public int? IdEstado { get; set; }
        public DateTime? FechaCreacion { get; set; }
    }
}