namespace GestorProyectos.Core.Models
{
    public partial class LugaresImplementaciones
    {
        public int IdImplementacion { get; set; }
        public int? IdProyecto { get; set; }
        public int? IdProvincia { get; set; }
        public int? IdMunicipio { get; set; }
        public int? IdDistrito { get; set; }
        public int? IdSeccion { get; set; }
        public int? IdBarrio { get; set; }

        public virtual Barrios? Barrio { get; set; }
        public virtual DistritosMunicipales? DistritosMunicipal { get; set; }
        public virtual Municipios? Municipio { get; set; }
        public virtual Provincias? Provincia { get; set; }
        public virtual Proyectos? Proyecto { get; set; }
        public virtual Secciones? Seccion { get; set; }
    }
}