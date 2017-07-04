using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ExceptionFilter.API.Filter;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ExceptionFilter.API.Controllers
{
    [Route("api/[controller]")]
    [ErrorHandlingFilter]
    public class CaosController : Controller
    {
        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var zero = 0;
            var result = 1 / zero;
            return new string[] { "If you got this message, the world once we know is gone. keeping our humanity? That's a choice. Your result: " + result };
        }

        
        [HttpGet("GetIoException")]
        public string GetIoException()
        {
            OuterLib.Io.IoException();
            return "value";
        }

        [HttpGet("GetImageException")]
        public string GetImageException()
        {
            OuterLib.Image.BadImageFormatException();
            return "value";
        }

        [HttpGet("GetArgumentOutOfRange")]
        public string GetArgumentOutOfRange()
        {
            OuterLib.Argument.ArgumentOutOfRangeException();
            return "value";
        }

        [HttpGet("GetArgumentEx")]
        public string GetArgumentEx()
        {
            OuterLib.Argument.ArgumentEx();
            return "value";
        }

        [HttpGet("GetArgumentNullException")]
        public string GetArgumentNullException()
        {
            OuterLib.Argument.ArgumentNullException();
            return "value";
        }

        [HttpGet("GetHttpRequestException")]
        public void GetHttpRequestException()
        {
            throw new HttpRequestException();
 
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
