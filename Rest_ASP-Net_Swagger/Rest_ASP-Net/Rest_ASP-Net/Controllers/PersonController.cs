using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rest_ASP_Net.Model;
using Rest_ASP_Net.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Rest_ASP_Net.Data.VO;
using Rest_ASP_Net.Hypermedia.Filters;

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
        [ProducesResponseType((200),Type=typeof(List<PersonVO>))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]

        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Get()
        {


            return Ok(_personBusiness.FindAll());

        }

        [HttpGet("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
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
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Post_Create([FromBody] PersonVO person)
        {

            if (person == null) return BadRequest();
            return Ok(_personBusiness.Create(person));

        }
        [HttpPut]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        [TypeFilter(typeof(HyperMediaFilter))]
        public IActionResult Put_Update([FromBody] PersonVO person)
        {

            if (person == null) return BadRequest();
            return Ok(_personBusiness.Update(person));

        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType((200), Type = typeof(PersonVO))]
        [ProducesResponseType((204))]
        [ProducesResponseType((400))]
        [ProducesResponseType((401))]
        public IActionResult Delete_Delete(long id)
        {


            _personBusiness.Delete(id);
            return NoContent();

        }

    }
}
