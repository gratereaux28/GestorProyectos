using AutoMapper;
using GestorProyectos.Base.Implementations;
using GestorProyectos.Core.Interfaces;
using GestorProyectos.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GestorProyectos.Api.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController<Usuarios>
    {
        private readonly IConfiguration _configuration;

        public AccountController(IConfiguration configuration) : base()
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Authentication(Usuarios login)
        {
            //if it is a valid user
            if (IsValidUser(login))
            {
                var token = GenerateToken();
                return Ok(new { token });
            }

            return NotFound();
        }

        private bool IsValidUser(Usuarios login)
        {
            return true;
        }

        private string GenerateToken()
        {
            //Header
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, "Martin Gratereaux"),
                new Claim("User", "mgratereaux"),
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
