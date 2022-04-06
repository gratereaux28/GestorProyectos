using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.QueryFilter
{
    public partial class DistritosMunicipalesQueryFilter : BaseQueryFilter
    {
        public int? IdDistrito { get; set; }
        public int? IdMunicipio { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public IEnumerable<int>? IdsMunicipio { get; set; }
        public IEnumerable<string>? Nombres { get; set; }
    }
}
