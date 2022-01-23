using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.DTOs
{
    public partial class MunicipiosDto
    {
        public int IdMunicipio { get; set; }
        public int IdProvincia { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public virtual ProvinciasDto Provincia { get; set; } = null!;
        public virtual ICollection<DistritosMunicipalesDto> DistritosMunicipales { get; set; }
        public virtual ICollection<TerritoriosImpactadosDto> TerritoriosImpactados { get; set; }
    }
}
