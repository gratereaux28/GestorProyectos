using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.QueryFilter
{
    public partial class MunicipiosQueryFilter : BaseQueryFilter
    {
        public int? IdMunicipio { get; set; }
        public int? IdProvincia { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public IEnumerable<int>? IdsProvincia { get; set; }
        public IEnumerable<string>? Nombres { get; set; }
    }
}