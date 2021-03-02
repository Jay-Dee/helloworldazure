using System.Linq;
using helloazure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace helloazure.Controllers {
    public class PersonsController : ControllerBase{
        private readonly PersonContext _context;

        public PersonsController(PersonContext context)
        {
            _context = context;

            if(!_context.Persons.Any())
            {
                PersonGenerator.InitData(_context);
            }
        }


        [HttpGet("api/get-persons")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IQueryable<Person>> GetPersons([FromQuery] PersonsRequest request)
        {
            var result = _context.Persons as IQueryable<Person>;
            
            Response.Headers["x-total-count"] = result.Count().ToString();

            return Ok(result
                    .OrderBy(p => p.Id)
                    .Skip(request.Offset)
                    .Take(request.Limit));
        }

    }
}