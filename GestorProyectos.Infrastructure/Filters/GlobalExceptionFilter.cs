using GestorProyectos.Core.Exceptions;
using GestorProyectos.Infrastructure.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Net;

namespace GestorProyectos.Infrastructure.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string Controller = context.ActionDescriptor.RouteValues.FirstOrDefault(r => r.Key == "controller").Value;
            string ActionName = context.ActionDescriptor.RouteValues.FirstOrDefault(r => r.Key == "action").Value;
            string User = context.HttpContext.User.Claims.FirstOrDefault(c => c.Type == "User").Value;
            LogHelper.Write($"{Controller}/{ActionName}", User, context.Exception);

            if (context.Exception.GetType() == typeof(BusinessException))
            {
                var exception = (BusinessException)context.Exception;
                var validation = new
                {
                    Status = 400,
                    Title = "Bad Request",
                    Detail = exception.Message
                };

                var json = new
                {
                    errors = new[] { validation }
                };

                context.Result = new BadRequestObjectResult(json);
                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.ExceptionHandled = true;
            }
        }
    }
}