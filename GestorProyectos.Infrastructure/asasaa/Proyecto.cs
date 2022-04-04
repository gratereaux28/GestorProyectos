using System;
using System.Collections.Generic;

namespace GestorProyectos.Infrastructure.asasaa
{
    public partial class Proyecto
    {
        public Proyecto()
        {
            Actividades = new HashSet<Actividade>();
            DesafiosProyectos = new HashSet<DesafiosProyecto>();
            DocumentosProyectos = new HashSet<DocumentosProyecto>();
            Ejecuciones = new HashSet<Ejecucione>();
            LugaresImplementaciones = new HashSet<LugaresImplementacione>();
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
        public int IdDonante { get; set; }
        public int IdAliado { get; set; }
        public int Anos { get; set; }
        public int Meses { get; set; }
        public int Dias { get; set; }
        public int IdRangoPresupuestario { get; set; }
        public decimal MontoPresupuestario { get; set; }
        public string TipoMoneda { get; set; } = null!;
        public int IdGerente { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? FechaCreacion { get; set; }

        public virtual Aliado IdAliadoNavigation { get; set; } = null!;
        public virtual RangoBeneficiario IdRangoPresupuestarioNavigation { get; set; } = null!;
        public virtual ICollection<Actividade> Actividades { get; set; }
        public virtual ICollection<DesafiosProyecto> DesafiosProyectos { get; set; }
        public virtual ICollection<DocumentosProyecto> DocumentosProyectos { get; set; }
        public virtual ICollection<Ejecucione> Ejecuciones { get; set; }
        public virtual ICollection<LugaresImplementacione> LugaresImplementaciones { get; set; }
        public virtual ICollection<TiposBeneficiarioProyecto> TiposBeneficiarioProyectos { get; set; }
    }
}
