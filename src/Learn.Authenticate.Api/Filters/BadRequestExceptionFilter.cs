using Learn.Authenticate.Shared.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Learn.Authenticate.Api.Filters
{
    internal class BadRequestExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is BadRequestException)
            {
                var exception = context.Exception as BadRequestException;

                if (exception.Code == 0)
                {
                    context.HttpContext.Response.StatusCode =  StatusCodes.Status400BadRequest;
                }
                else
                {
                    context.HttpContext.Response.StatusCode = exception.Code;
                }

                context.Result = new JsonResult(new
                {
                    message = context.Exception.GetBaseException().Message
                });

                base.OnException(context);
            }
        }
    }
}
