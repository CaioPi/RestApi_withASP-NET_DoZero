using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rest_ASP_Net.Model;
using Rest_ASP_Net.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_ASP_Net.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiversion}")]
    public class PersonController : ControllerBase
    {


        private  ILogger<PersonController> _logger;
        private  IPersonBusiness _personBusiness;

        public PersonController(ILogger<PersonController> logger, IPersonBusiness personBusiness)

        {
            _logger = logger;
            _personBusiness = personBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {


            return Ok(_personBusiness.FindAll());

        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {


            var personV = _personBusiness.FindById(id);
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
            return Ok(_personBusiness.Create(person));

        }
        [HttpPut]
        public IActionResult Put_Update([FromBody] Person person)
        {

            if (person == null) return BadRequest();
            return Ok(_personBusiness.Update(person));

        }
        [HttpDelete("{id}")]
        public IActionResult Delete_Delete(long id)
        {


            _personBusiness.Delete(id);
            return NoContent();

        }

    }
}
