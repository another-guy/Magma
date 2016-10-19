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
            
            if (exception is HttpException)
                HandleHttpException(context, exception);
            else if (exception is InvalidModelStateException)
                HandleInvalidModelStateException(context, exception);
            else if (exception is ArgumentException)
                HandleArgumentException(context, exception);
            else if (exception is InvalidOperationException)
                HandleAsInternalServiceError(context, exception);

            // context.ExceptionHandled = true;
        }

        private static void HandleHttpException(ExceptionContext context, Exception exception)
        {
            var httpException = (HttpException)exception;
            context.Result = new JsonResult(httpException.Message)
            {
                StatusCode = (int)httpException.HttpStatusCode
            };
        }

        private static void HandleInvalidModelStateException(ExceptionContext context, Exception exception)
        {
            var invalidModelException = (InvalidModelStateException)exception;
            context.Result = new BadRequestObjectResult(invalidModelException.ModelState);
        }

        private static void HandleArgumentException(ExceptionContext context, Exception exception)
        {
            context.Result = new BadRequestObjectResult(exception.Message);
        }

        private static void HandleAsInternalServiceError(ExceptionContext context, Exception exception)
        {
            context.Result = new JsonResult(exception.Message)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}
