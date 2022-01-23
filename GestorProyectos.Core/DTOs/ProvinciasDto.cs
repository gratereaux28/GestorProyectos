using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.DTOs
{
    public partial class ProvinciasDto
    {
        public int IdProvincia { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public virtual ICollection<LugaresImplementacionesDto> LugaresImplementaciones { get; set; }
        public virtual ICollection<MunicipiosDto> Municipios { get; set; }
    }
}
