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
using System.Net;
using System.Threading.Tasks;

namespace GestorProyectos.Api.Controllers
{
    public class UsuariosController : BaseController<Usuarios>
    {
        protected IUriService _uriService;
        protected IUsuariosService _currentService;
        protected IPasswordService _passwordService;

        public UsuariosController(IUsuariosService currentService, IPasswordService passwordService, IMapper mapper, IUriService uriService) : base()
        {
            _currentService = currentService;
            _passwordService = passwordService;
            _mapper = mapper;
            _uriService = uriService;
        }

        /// <summary>
        /// Devuelve un listado de todos las Usuarios.
        /// </summary>
        /// <param name="filters">Filtros de Consulta a aplicar.</param>
        /// <returns></returns>
        [HttpGet (Name = nameof(GetUsuarios))]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(IEnumerable<UsuariosDto>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetUsuarios([FromQuery] UsuariosQueryFilter filters)
        {
            var result = await _currentService.ObtenerUsuarios(filters);
            var dto = _mapper.Map<IEnumerable<UsuariosDto>>(result);
            foreach (var item in dto)
            {
                item.Clave = "";
            }
            var data = await dto.returnResponse();
            return Ok(data);
        }

        /// <summary>
        /// Devuelve un Usuario en especifico.
        /// </summary>
        /// <param name="id">Id del Usuario.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _currentService.ObtenerUsuario(id);
            var dto = _mapper.Map<UsuariosDto>(result);
            dto.Clave = "";
            var data = await dto.returnResponse();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Post(UsuariosDto dtoModel)
        {
            var model = _mapper.Map<Usuarios>(dtoModel);
            model.Clave = _passwordService.Hash(model.Clave);
            var result = await _currentService.AgregarUsuario(model);
            result.Clave = "";
            dtoModel = _mapper.Map<UsuariosDto>(model);
            var data = await dtoModel.returnResponse();
            return Ok(data);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int Id, UsuariosDto dtoModel)
        {
            dtoModel.IdUsuario = Id;
            var result = await _currentService.ActualizarUsuario(_mapper.Map<Usuarios>(dtoModel));
            var data = await result.returnResponse();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _currentService.EliminarUsuario(id);
            var data = await result.returnResponse();
            return Ok(data);
        }
    }
}