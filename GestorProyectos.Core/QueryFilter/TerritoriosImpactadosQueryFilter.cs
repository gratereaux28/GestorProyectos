﻿using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.QueryFilter
{
    public partial class TerritoriosImpactadosQueryFilter : BaseQueryFilter
    {
        public int? IdImpacto { get; set; }
        public int? IdProyecto { get; set; }
        public int? IdMunicipio { get; set; }
        public int? IdBarrio { get; set; }
    }
}