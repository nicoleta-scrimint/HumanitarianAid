using Microsoft.AspNetCore.Mvc;

namespace Centric.HumanitarianAid.API.Person
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly PersonRepository _personRepository;

		public PersonsController(PersonRepository personRepository)
		{
			_personRepository = personRepository;
		}

		[HttpGet]
		[ProducesResponseType(StatusCodes.Status200OK)]
		public IActionResult Get()
		{
			return Ok(_personRepository.GetAll());
		}
	}
}