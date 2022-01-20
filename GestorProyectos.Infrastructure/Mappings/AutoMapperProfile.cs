using AutoMapper;
using GestorProyectos.Core.DTOs;
using GestorProyectos.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorProyectos.Infrastructure.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Estados, EstadosDto>();
            CreateMap<EstadosDto, Estados>();
        }
    }
}
