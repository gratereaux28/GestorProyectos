﻿using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;

namespace GestorProyectos.Core.Interfaces.Services
{
    public interface IMunicipiosService
    {
        Task<Municipios> ObtenerMunicipio(int IdMunicipio);
        Task<IEnumerable<Municipios>> ObtenerMunicipios(MunicipiosQueryFilter filters);
    }
}