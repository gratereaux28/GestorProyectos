using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class Provincias
    {
        public Provincias()
        {
            LugaresImplementaciones = new HashSet<LugaresImplementaciones>();
            Municipios = new HashSet<Municipios>();
        }

        public int IdProvincia { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public virtual ICollection<LugaresImplementaciones> LugaresImplementaciones { get; set; }
        public virtual ICollection<Municipios> Municipios { get; set; }
    }
}
