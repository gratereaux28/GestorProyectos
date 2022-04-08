using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.Interfaces.Services;
using GestorProyectos.Core.Models;
using GestorProyectos.Core.QueryFilter;
using GestorProyectos.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GestorProyectos.Api.Controllers
{
    [AllowAnonymous]
    public class LoginController : BaseController<Usuarios>
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuariosService _usuariosService;
        private readonly IPasswordService _passwordService;
        private readonly IOlvidoClaveService _olvidoClaveService;

        public LoginController(IUsuariosService usuariosService, IPasswordService passwordService, IOlvidoClaveService olvidoClaveService, IConfiguration configuration) : base()
        {
            _usuariosService = usuariosService;
            _passwordService = passwordService;
            _configuration = configuration;
            _olvidoClaveService = olvidoClaveService;
        }

        /// <summary>
        /// Interaccion de Inicio de session.
        /// </summary>
        /// <param name="usuario">Usuario.</param>
        /// <param name="clave">Clave.</param>
        /// <returns></returns>
        [HttpPost(Name = nameof(Login))]
        public async Task<IActionResult> Login(string usuario, string clave)
        {
            var user = await _usuariosService.ObtenerUsuario(usuario);

            if (user != null)
            {
                var IsValidUser = _passwordService.Check(user.Clave, clave);
                if (IsValidUser)
                {
                    var token = GenerateToken(user);
                    string Nombre = user.Nombre + " " + user.Apellido;
                    return Ok(new { Nombre, user.Usuario, token });
                }
            }

            return Ok(false);
        }

        private string GenerateToken(Usuarios usuario)
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nombre + " " + usuario.Apellido),
                new Claim("User", usuario.Usuario),
                new Claim(ClaimTypes.Role, "Administrador"),
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddDays(1)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPut("{usuario}")]
        public async Task<IActionResult> OlvidoClave(string usuario)
        {
            var user = await _usuariosService.ObtenerUsuario(usuario);

            if (user != null)
            {
                var Clave = _configuration["ProyectInfo:DefaultPassword"];
                user.Clave = _passwordService.Hash(Clave);
                await _usuariosService.ActualizarUsuario(user);
                await _olvidoClaveService.EnviarClave(usuario, Clave);
                return Ok(true); 
            }

            return Ok(false);
        }

    }
}