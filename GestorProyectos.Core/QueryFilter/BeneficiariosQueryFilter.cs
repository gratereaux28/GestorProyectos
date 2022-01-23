using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.QueryFilter
{
    public partial class BeneficiariosQueryFilter : BaseQueryFilter
    {
        public int IdBeneficiario { get; set; }
        public string Nombre { get; set; } = null!;
    }
}