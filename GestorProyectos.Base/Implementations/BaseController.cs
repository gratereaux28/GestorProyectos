using Microsoft.AspNetCore.Mvc;
using System;

namespace GestorProyectos.Base.Implementations
{
    [ApiController]
    [Route("[controller]")]
    public class BaseController : ControllerBase
    {
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