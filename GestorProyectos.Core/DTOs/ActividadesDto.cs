using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.DTOs
{
    public partial class ActividadesDto
    {
        public int? IdActividad { get; set; }
        public string? Descripcion { get; set; }
        public int? IdProyecto { get; set; }
        public int? Orden { get; set; }

        public IEnumerable<TareasDto> Tareas { get; set; }
    }
}
