using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rest_ASP_Net.Model;
using Rest_ASP_Net.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_ASP_Net.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {


        private readonly ILogger<PersonController> _logger;
        private IPersonService _personservice;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)

        {
            _logger = logger;
            _personservice = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {


            return Ok(_personservice.FindAll());

        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {


            var personV = _personservice.FindById(id);
            if (personV == null)
            {
                return NotFound();
            }

            return Ok(personV);

        }
        [HttpPost]
        public IActionResult Post_Create([FromBody] Person person)
        {

            if (person == null) return BadRequest();
            return Ok(_personservice.Create(person));

        }
        [HttpPut]
        public IActionResult Put_Update([FromBody] Person person)
        {

            if (person == null) return BadRequest();
            return Ok(_personservice.Update(person));

        }
        [HttpDelete("{id}")]
        public IActionResult Delete_Delete(long id)
        {


            _personservice.Delete(id);
            return NoContent();

        }

    }
}
