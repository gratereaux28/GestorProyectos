namespace GestorProyectos.Core.Models
{
    public partial class Proyectos
    {
        public Proyectos()
        {
            Actividades = new HashSet<Actividades>();
            DesafiosProyectos = new HashSet<DesafiosProyectos>();
            DocumentosProyectos = new HashSet<DocumentosProyectos>();
            Ejecuciones = new HashSet<Ejecuciones>();
            LugaresImplementaciones = new HashSet<LugaresImplementaciones>();
            TiposBeneficiarioProyectos = new HashSet<TiposBeneficiarioProyecto>();
        }

        public int IdProyecto { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public string? ObjetivoGeneral { get; set; }
        public string? ObjetivoEspecifico { get; set; }
        public string? Resultados { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public int IdRangoBeneficiario { get; set; }
        public int CantidadBeneficiarios { get; set; }
        public int Anos { get; set; }
        public int Meses { get; set; }
        public int Dias { get; set; }
        public int IdRangoPresupuestario { get; set; }
        public decimal MontoPresupuestario { get; set; }
        public string TipoMoneda { get; set; } = null!;
        public int IdGerente { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual RangoBeneficiarios RangoBeneficiarios { get; set; } = null!;
        public virtual Aliado Aliado { get; set; } = null!;
        public virtual Donantes Donante { get; set; } = null!;
        public virtual ICollection<Actividades> Actividades { get; set; }
        public virtual ICollection<DesafiosProyectos> DesafiosProyectos { get; set; }
        public virtual ICollection<DocumentosProyectos> DocumentosProyectos { get; set; }
        public virtual ICollection<Ejecuciones> Ejecuciones { get; set; }
        public virtual ICollection<LugaresImplementaciones> LugaresImplementaciones { get; set; }
        public virtual ICollection<TiposBeneficiarioProyecto> TiposBeneficiarioProyectos { get; set; }
    }
}