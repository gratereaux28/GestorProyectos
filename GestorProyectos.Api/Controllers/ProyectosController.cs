using AutoMapper;
using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.DTOs;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Extensions.sys;
using GestorProyectos.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace GestorProyectos.Api.Controllers
{
    public class ProyectosController : BaseController<Proyectos>
    {
        protected IUriService _uriService;
        protected IProyectosService _currentService;

        public ProyectosController(IProyectosService currentService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos los Proyectos.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetProyectos))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<ProyectosDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetProyectos([FromQuery] ProyectosQueryFilter filters)
        {
            var result = await _currentService.ObtenerProyectos(filters);
            var dto = _mapper.Map<IEnumerable<ProyectosDto>>(result);
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve un Proyecto en especifico.
        /// </summary>
        /// <param name="id">Id del Barrio.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerProyecto(id);
            var dto = _mapper.Map<ProyectosDto>(result);

            if(result.DesafiosProyectos != null && result.DesafiosProyectos.Count() > 0)
            dto.DesafiosProyecto = _mapper.Map<DesafiosProyectosDto>(result.DesafiosProyectos.FirstOrDefault());

            if (result.TiposBeneficiarioProyectos != null && result.TiposBeneficiarioProyectos.Count() > 0)
                dto.TiposBeneficiarioProyecto = _mapper.Map<TiposBeneficiarioProyectoDto>(result.TiposBeneficiarioProyectos.FirstOrDefault());

            if (result.LugaresImplementaciones != null && result.LugaresImplementaciones.Count() > 0)
                dto.LugaresImplementacione = _mapper.Map<LugaresImplementacionesDto>(result.LugaresImplementaciones.FirstOrDefault());

            var data = await dto.returnResponse();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProyectosDto dtoModel)
        {
            var model = _mapper.Map<Proyectos>(dtoModel);
            model.Usuario = LoggedUser;

            model.DesafiosProyectos = new List<DesafiosProyectos>();
            model.TiposBeneficiarioProyectos = new List<TiposBeneficiarioProyecto>();
            model.LugaresImplementaciones = new List<LugaresImplementaciones>();

            if(dtoModel.DesafiosProyecto != null)
                model.DesafiosProyectos.Add(_mapper.Map<DesafiosProyectos>(dtoModel.DesafiosProyecto));

            if (dtoModel.TiposBeneficiarioProyecto != null)
                model.TiposBeneficiarioProyectos.Add(_mapper.Map<TiposBeneficiarioProyecto>(dtoModel.TiposBeneficiarioProyecto));

            if (dtoModel.LugaresImplementacione != null)
                model.LugaresImplementaciones.Add(_mapper.Map<LugaresImplementaciones>(dtoModel.LugaresImplementacione));

            var result = await _currentService.AgregarProyecto(model, dtoModel.DocumentosProyectos);
            dtoModel = _mapper.Map<ProyectosDto>(result);
            var data = await dtoModel.returnResponse();
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int Id, ProyectosDto dtoModel)
        {
            dtoModel.IdProyecto = Id;

            dtoModel.DesafiosProyectos = new List<DesafiosProyectosDto>();
            dtoModel.TiposBeneficiarioProyectos = new List<TiposBeneficiarioProyectoDto>();
            dtoModel.LugaresImplementaciones = new List<LugaresImplementacionesDto>();

            if (dtoModel.DesafiosProyecto != null)
                dtoModel.DesafiosProyectos.Add(dtoModel.DesafiosProyecto);

            if (dtoModel.TiposBeneficiarioProyecto != null)
                dtoModel.TiposBeneficiarioProyectos.Add(dtoModel.TiposBeneficiarioProyecto);

            if (dtoModel.LugaresImplementacione != null)
                dtoModel.LugaresImplementaciones.Add(dtoModel.LugaresImplementacione);

            var proyecto = _mapper.Map<Proyectos>(dtoModel);

            var result = await _currentService.ActualizarProyecto(proyecto, dtoModel.DocumentosProyectos);
            var data = await result.returnResponse();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _currentService.EliminarProyecto(id);
            var data = await result.returnResponse();
            return Ok(data);
        }
    }
}