using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Security.Claims;

namespace GestorProyectos.Base.Implementations
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TEntity> : ControllerBase where TEntity : class
    {
        protected IMapper _mapper;

        public BaseController()
        {
        }
        public string LoggedUser => GetLoggedUser();

        private string GetLoggedUser()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var claims = identity.Claims;

            return claims.FirstOrDefault(x => x.Type == "User").Value;
        }

        protected Exception GetInnerException(Exception ex)
        {
            var currentEx = ex;
            while (currentEx.InnerException != null)
            {
                currentEx = currentEx.InnerException;
            }

            return currentEx;
        }
    }
}