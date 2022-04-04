using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class LugaresImplementacione
    {
        public int IdImplementacion { get; set; }
        public int? IdProyecto { get; set; }
        public int? IdProvincia { get; set; }
        public int? IdMunicipio { get; set; }
        public int? IdDistrito { get; set; }
        public int? IdSeccion { get; set; }
        public int? IdBarrio { get; set; }

        public virtual Barrio? IdBarrioNavigation { get; set; }
        public virtual DistritosMunicipale? IdDistritoNavigation { get; set; }
        public virtual Municipio? IdMunicipioNavigation { get; set; }
        public virtual Provincia? IdProvinciaNavigation { get; set; }
        public virtual Proyecto? IdProyectoNavigation { get; set; }
        public virtual Seccione? IdSeccionNavigation { get; set; }
    }
}
