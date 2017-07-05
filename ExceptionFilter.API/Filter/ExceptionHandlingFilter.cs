using System.Net;
using Microsoft.AspNetCore.Mvc.Filters;
using ExceptionFilter.API.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionFilter.API.Filter
{
    public class ExceptionHandlingFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            context.Result = new JsonResult(PrepareResponseObject(context));
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            base.OnException(context);
            context.ExceptionHandled = true;
        }

        private ApiReponse<object> PrepareResponseObject(ExceptionContext context)
        {
           return  ApiReponse<object>.Exception(new object(), context.Exception.Message, context.Exception.StackTrace);
        }
    }
}
