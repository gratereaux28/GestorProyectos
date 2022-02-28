using GestorProyectos.Core.DTOs;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using System.Linq.Expressions;

namespace GestorProyectos.Core.Services
{
    public class TerritoriosImpactadosService : ITerritoriosImpactadosService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TerritoriosImpactadosService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TerritoriosImpactados> ObtenerImpacto(int IdImpacto)
        {
            var query = await _unitOfWork.TerritoriosImpactadosRepository.GetAsync(e => e.IdImpacto == IdImpacto);
            var Impacto = query.FirstOrDefault();
            return Impacto;
        }

        public async Task<IEnumerable<TerritoriosImpactados>> ObtenerTerritoriosImpactados(TerritoriosImpactadosQueryFilter filters)
        {
            List<Expression> expressions = new List<Expression>();

            if (filters.IdImpacto != null && filters.IdImpacto != 0)
            {
                Expression<Func<TerritoriosImpactados, bool>> query = (e => e.IdImpacto == filters.IdImpacto);
                expressions.Add(query);
            }
            if (filters.IdProyecto != null && filters.IdProyecto != 0)
            {
                Expression<Func<TerritoriosImpactados, bool>> query = (e => e.IdProyecto == filters.IdProyecto);
                expressions.Add(query);
            }
            if (filters.IdMunicipio != null && filters.IdMunicipio != 0)
            {
                Expression<Func<TerritoriosImpactados, bool>> query = (e => e.IdMunicipio == filters.IdMunicipio);
                expressions.Add(query);
            }
            if (filters.IdBarrio != null && filters.IdBarrio != 0)
            {
                Expression<Func<TerritoriosImpactados, bool>> query = (e => e.IdBarrio == filters.IdBarrio);
                expressions.Add(query);
            }

            var data = await _unitOfWork.TerritoriosImpactadosRepository.GetAsync(expressions);
            return data;
        }

        public async Task<IEnumerable<TerritoriosImpactados>> ObtenerListaTerritoriosImpactados(List<int> ids)
        {
            var municipios = await _unitOfWork.MunicipiosRepository.AddInclude("DistritosMunicipales").GetAsync(m => ids.Contains(m.IdProvincia));
            var distritos = await _unitOfWork.DistritosMunicipalesRepository.AddInclude("Secciones").GetAsync(m => municipios.ToList().Select(m => m.IdMunicipio).Contains(m.IdMunicipio));
            var secciones = await _unitOfWork.SeccionesRepository.AddInclude("Barrios").GetAsync(m => distritos.ToList().Select(m => m.IdDistrito).Contains(m.IdDistrito));

            List<TerritoriosImpactados> territoriosImpactados = new();

            foreach (var municipio in municipios)
                territoriosImpactados.Add(new TerritoriosImpactados {
                    IdMunicipio = municipio.IdMunicipio,
                    Municipio = municipio
                });

            foreach (var seccion in secciones)
                foreach (var barrio in seccion.Barrios)
                    territoriosImpactados.Add(new TerritoriosImpactados
                    {
                        IdBarrio = barrio.IdBarrio,
                        Barrio = barrio
                    });

            return territoriosImpactados;
        }

        public async Task<TerritoriosImpactados> AgregarImpacto(TerritoriosImpactados impacto)
        {
            impacto.IdImpacto = 0;
            return await _unitOfWork.TerritoriosImpactadosRepository.AddAsync(impacto);
        }

        public async Task<bool> ActualizarImpacto(TerritoriosImpactados impacto)
        {
            var Impacto = await ObtenerImpacto(impacto.IdImpacto);
            if (Impacto != null)
            {
                impacto.CopyTo(Impacto);
                _unitOfWork.TerritoriosImpactadosRepository.UpdateNoSave(Impacto);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }

        public async Task<bool> EliminarImpacto(int IdImpacto)
        {
            var Impacto = await ObtenerImpacto(IdImpacto);
            if (Impacto != null)
            {
                _unitOfWork.TerritoriosImpactadosRepository.DeleteNoSave(Impacto);
                await _unitOfWork.SaveChangesAsync();
                return true;
            }
            else
                return false;
        }
    }
}