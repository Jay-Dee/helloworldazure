using System.Linq;
using helloazure.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace helloazure.Controllers {
    public class PersonsController : ControllerBase{
        private readonly PersonContext _context;
        private readonly ILogger<PersonsController> _logger;

        public PersonsController(PersonContext context, ILogger<PersonsController> logger)
        {
            _context = context;
            _logger = logger;
            if (!_context.Persons.Any())
            {
                PersonGenerator.InitData(_context);
            }
        }


        [HttpGet("api/get-persons")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IQueryable<Person>> GetPersons([FromQuery] PersonsRequest request)
        {
            _logger.LogInformation($"Processing GET request for extracting {request.Limit} items after {request.Offset}");
            var result = _context.Persons as IQueryable<Person>;

            _logger.LogInformation($"Successfully extracted {result.Count()} items in total");
            Response.Headers["x-total-count"] = result.Count().ToString();

            return Ok(result
                    .OrderBy(p => p.Id)
                    .Skip(request.Offset)
                    .Take(request.Limit));
        }

    }
}