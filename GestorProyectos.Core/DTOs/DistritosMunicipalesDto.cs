using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.DTOs
{
    public partial class DistritosMunicipalesDto
    {
        public int IdDistrito { get; set; }
        public int IdMunicipio { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public virtual MunicipiosDto Municipio { get; set; } = null!;
        public virtual ICollection<SeccionesDto> Secciones { get; set; }
    }
}
