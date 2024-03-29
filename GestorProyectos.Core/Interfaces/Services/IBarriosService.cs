﻿using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IBarriosService
    {
        Task<Barrios> ObtenerBarrio(int IdBarrio);
        Task<IEnumerable<Barrios>> ObtenerBarrios(BarriosQueryFilter filters);
    }
}