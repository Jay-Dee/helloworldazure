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

        [HttpGet]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IQueryable<Person>> GetPersons()
        {
            var result = _context.Persons as IQueryable<Person>;

            return Ok(result
              .OrderBy(p => p.Id));
        }

    }
}