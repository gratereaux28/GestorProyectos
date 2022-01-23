using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class Secciones
    {
        public Secciones()
        {
            Barrios = new HashSet<Barrios>();
        }

        public int IdSeccion { get; set; }
        public int IdDistrito { get; set; }
        public string? Nombre { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }

        public virtual DistritosMunicipales DistritoMunicipal { get; set; } = null!;
        public virtual ICollection<Barrios> Barrios { get; set; }
    }
}
