using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace GestorProyectos.Base.Implementations
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<TController, TEntity> : ControllerBase where TController : class
    {
        protected ILogger<TController> _logger;
        protected IMapper _mapper;

        public BaseController()
        {

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