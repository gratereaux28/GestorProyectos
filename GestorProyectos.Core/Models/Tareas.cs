namespace GestorProyectos.Core.Models
{
    public partial class Tareas
    {
        public Tareas()
        {
            DocumentosProyectos = new HashSet<DocumentosProyectos>();
        }

        public int IdTarea { get; set; }
        public string Descripcion { get; set; } = null!;
        public int IdActividad { get; set; }
        public int? Meta { get; set; }
        public string? Periodo { get; set; }
        public int? Meses { get; set; }
        public int? Dias { get; set; }
        public decimal? MontoPresupuestarioDOP { get; set; }
        public decimal? MontoPresupuestarioUSD { get; set; }
        public string? Resultado { get; set; }
        public string? PosiblesRiesgos { get; set; }
        public string? AccionMitigacion { get; set; }
        public int? IdResponsable { get; set; }
        public int IdEstado { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Actividades Actividad { get; set; } = null!;
        public virtual Estados Estado { get; set; } = null!;
        public virtual Usuarios? Usuario { get; set; }
        public virtual ICollection<DocumentosProyectos> DocumentosProyectos { get; set; }
    }
}