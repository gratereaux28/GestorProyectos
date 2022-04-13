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
            CreateMap<Actividades, ActividadesDto>().ReverseMap();
            CreateMap<Aliado, AliadoDto>().ReverseMap();
            CreateMap<AliadoClasificaciones, AliadoClasificacionesDto>().ReverseMap();
            CreateMap<Barrios, BarriosDto>().ReverseMap();
            CreateMap<Beneficiarios, BeneficiariosDto>().ReverseMap();
            CreateMap<Desafios, DesafiosDto>().ReverseMap();
            CreateMap<DesafiosProyectos, DesafiosProyectosDto>().ReverseMap();
            CreateMap<DistritosMunicipales, DistritosMunicipalesDto>().ReverseMap();
            CreateMap<DivisionTrabajoProyectos, DivisionTrabajoProyectosDto>().ReverseMap();
            CreateMap<DocumentosProyectos, DocumentosProyectosDto>().ReverseMap();
            CreateMap<DonacionClasificaciones, DonacionClasificacionesDto>().ReverseMap();
            CreateMap<Donantes, DonantesDto>().ReverseMap();
            CreateMap<DonantesClasificaciones, DonantesClasificacionesDto>().ReverseMap();
            CreateMap<Ejecuciones, EjecucionesDto>().ReverseMap();
            CreateMap<Estados, EstadosDto>().ReverseMap();
            CreateMap<LugaresImplementaciones, LugaresImplementacionesDto>().ReverseMap();
            CreateMap<Municipios, MunicipiosDto>().ReverseMap();
            CreateMap<NivelAcceso, NivelAccesoDto>().ReverseMap();
            CreateMap<Provincias, ProvinciasDto>().ReverseMap();
            CreateMap<Proyectos, ProyectosDto>().ReverseMap();
            CreateMap<RangoBeneficiarios, RangoBeneficiariosDto>().ReverseMap();
            CreateMap<RangoPresupuestario, RangoPresupuestarioDto>().ReverseMap();
            CreateMap<Secciones, SeccionesDto>().ReverseMap();
            CreateMap<Tareas, TareasDto>().ReverseMap();
            CreateMap<TipoBeneficiario, TipoBeneficiarioDto>().ReverseMap();
            CreateMap<TiposBeneficiarioProyecto, TiposBeneficiarioProyectoDto>().ReverseMap();
            CreateMap<Usuarios, UsuariosDto>().ReverseMap();
        }
    }
}
