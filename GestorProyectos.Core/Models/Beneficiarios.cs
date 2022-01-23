using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.Models
{
    public partial class Beneficiarios
    {
        public int IdBeneficiario { get; set; }
        public string Nombre { get; set; } = null!;
    }
}