using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.DTOs
{
    public partial class ProvinciasDto
    {
        public int? IdProvincia { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public virtual IEnumerable<MunicipiosDto>? Municipios { get; set; }
    }
}
