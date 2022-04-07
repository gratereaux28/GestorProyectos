using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.DTOs
{
    public partial class ProyectosDto
    {
        public int? IdProyecto { get; set; }
        public string? Codigo { get; set; } = null!;
        public string? Nombre { get; set; } = null!;
        public string? Descripcion { get; set; } = null!;
        public string? ObjetivoGeneral { get; set; }
        public string? ObjetivoEspecifico { get; set; }
        public string? Resultados { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFinal { get; set; }
        public int? IdRangoBeneficiario { get; set; }
        public int? CantidadBeneficiarios { get; set; }
        public int? Anos { get; set; }
        public int? Meses { get; set; }
        public int? Dias { get; set; }
        public int? IdRangoPresupuestario { get; set; }
        public decimal? MontoPresupuestarioDOP { get; set; }
        public decimal? MontoPresupuestarioUSD { get; set; }
        public string? TipoMoneda { get; set; } = null!;
        public int? IdGerente { get; set; }
        public bool? IsDelete { get; set; }
        public string? Usuario { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual AliadoDto? Aliado { get; set; }
        public virtual DonantesDto? Donante { get; set; }
        public virtual ICollection<DesafiosProyectosDto>? DesafiosProyectos { get; set; }
        public virtual ICollection<DocumentosProyectosDto>? DocumentosProyectos { get; set; }
        public virtual ICollection<LugaresImplementacionesDto>? LugaresImplementaciones { get; set; }
        public virtual ICollection<ActividadesDto>? Actividades { get; set; }
        public virtual ICollection<TiposBeneficiarioProyectoDto>? TiposBeneficiarioProyectos { get; set; }
    }
}