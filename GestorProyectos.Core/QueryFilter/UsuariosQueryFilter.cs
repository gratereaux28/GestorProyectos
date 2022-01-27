using System;
using System.Collections.Generic;

namespace GestorProyectos.Core.QueryFilter
{
    public partial class UsuariosQueryFilter : BaseQueryFilter
    {
        public int? IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Correo { get; set; }
        public string? Usuario { get; set; }
        public string? Clave { get; set; }
    }
}