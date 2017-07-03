using Microsoft.AspNetCore.Mvc.Filters;
using ExceptionFilter.API.Response;
using Microsoft.AspNetCore.Mvc;

namespace ExceptionFilter.API.Filter
{
    public class ErrorHandlingFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var subject = context.Exception.Message;
            var message = context.Exception.StackTrace;
            var apiError = ApiReponse<object>.Exception(new object(), subject, message);
            context.Result = new JsonResult(apiError);

            base.OnException(context);
            context.ExceptionHandled = true;
        }
    }
}
