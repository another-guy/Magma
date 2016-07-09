using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Magma.Web.Http.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            // TODO This logic should be improved
            if (exception is InvalidModelStateException)
            {
                context.Result = new BadRequestObjectResult(((InvalidModelStateException)exception).ModelState);
            } else if (exception is ArgumentException)
            {
                context.Result = new BadRequestObjectResult(exception.Message);
            } else if (exception is InvalidOperationException)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }

            // context.ExceptionHandled = true;
        }
    }
}
