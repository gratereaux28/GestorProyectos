﻿using GestorProyectos.Base.Implementations;
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

        public LoginController(IUsuariosService usuariosService, IPasswordService passwordService, IConfiguration configuration) : base()
        {
            _usuariosService = usuariosService;
            _passwordService = passwordService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Login(UsuariosQueryFilter usuario)
        {
            var user = await _usuariosService.ObtenerUsuario(usuario.Usuario);
            var IsValidUser = _passwordService.Check(user.Clave, usuario.Clave);
            if (IsValidUser)
            {
                var token = GenerateToken(user);
                string Nombre = user.Nombre + " " + user.Apellido;
                return Ok(new { Nombre, user.Usuario, token });
            }

            return NotFound();
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
                DateTime.UtcNow.AddMinutes(3600)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}