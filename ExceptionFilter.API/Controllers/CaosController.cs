﻿using System;
using System.Collections.Generic;
using System.Linq;
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
            return new string[] { "If you got this message, take care, the world we know is about to explode. Your result: " + result };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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
