using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace ExceptionFilter.API.Response
{
    public class ApiReponse<T> : ActionResult
    {
        public HttpStatusCode Status { get; set; }
        public T Data { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public bool Error { get; set; }
        

        public static ApiReponse<T> OK(T data, string subject, string message)
        {
            return new ApiReponse<T>
            {
                Status = HttpStatusCode.OK, 
                Subject = subject,
                Message = message, 
                Data =  data, 
                Error = false
            };
        }
        public static ApiReponse<T> Exception(T data, string subject, string message)
        {
            return new ApiReponse<T>
            {
                Status = HttpStatusCode.InternalServerError,
                Subject = subject,
                Message = message,
                Data = data, 
                Error = true
            };
        }

        public override void ExecuteResult(ActionContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var response = context.HttpContext.Response;

            response.StatusCode = (int)Status;

            var jsonData = JsonConvert.SerializeObject(this, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            response.ContentLength = Encoding.UTF8.GetByteCount(jsonData);

            using (var textWriter = new HttpResponseStreamWriter(response.Body, new UTF8Encoding()))
            {
                textWriter.Write(jsonData);
                textWriter.Flush();
            }
        }

    }
}

