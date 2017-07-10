using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExceptionFilter.API.Filter;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ExceptionFilter.API.Controllers
{
    [Route("api/[controller]")]
    public class SpecificTreatedController : Controller
    {
        // GET: api/values
        [HttpGet("NoTreatment")]
        public IEnumerable<string> NoTreatment()
        {
            throw  new Exception();
        }

        // GET api/values/5
        [HttpGet("WithTreatment")]
        [ExceptionHandlingFilter]
        public string WithTreatment()
        {
            throw new Exception();
        }
        
    }
}
