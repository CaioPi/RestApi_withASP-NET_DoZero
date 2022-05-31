using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rest_ASP_Net.Business;
using Rest_ASP_Net.Data.VO;
using Rest_ASP_Net.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rest_ASP_Net.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiversion}")]
    public class BookController : ControllerBase
    {


        private ILogger<BookController> _logger;
        private IBookBusiness _bookBusiness;

        public BookController(ILogger<BookController> logger, IBookBusiness bookBusiness)

        {
            _logger = logger;
            _bookBusiness = bookBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {


            return Ok(_bookBusiness.FindAll());

        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {


            var personV = _bookBusiness.FindById(id);
            if (personV == null)
            {
                return NotFound();
            }

            return Ok(personV);

        }
        [HttpPost]
        public IActionResult Post_Create([FromBody] BookVO book)
        {

            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Create(book));

        }
        [HttpPut]
        public IActionResult Put_Update([FromBody] BookVO book)
        {

            if (book == null) return BadRequest();
            return Ok(_bookBusiness.Update(book));

        }
        [HttpDelete("{id}")]
        public IActionResult Delete_Delete(long id)
        {


            _bookBusiness.Delete(id);
            return NoContent();

        }

    }
}
