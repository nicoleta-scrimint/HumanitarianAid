using Microsoft.AspNetCore.Mvc;

namespace Centric.HumanitarianAid.API.Persons
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
			var persons = _personRepository.GetAll()
                .Select(x => new PersonDto
                {
                    Name = x.Name,
                    Surname = x.Surname,
                    Age = x.Age,
                    Gender = x.Gender.ToString()        
                });

            return Ok(persons);
        }
	}
}