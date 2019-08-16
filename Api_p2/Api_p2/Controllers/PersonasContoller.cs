using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service;

namespace Api_p2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PersonasController : Controller

    {
        private readonly IPersonaservice _personaservice;
        public PersonasController(IPersonaservice personaservice)
        {
            _personaservice = personaservice;

        }
        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(
                _personaservice.GetAll()
                );
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(
                _personaservice.Get(id)
                );
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Personas model)
        {
            return Ok(
                _personaservice.Add(model)
                );
        }

        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Personas model)
        {
            return Ok(
                _personaservice.Update(model)
                );
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(
               _personaservice.Delete(id)
               );
        }
    }
}
