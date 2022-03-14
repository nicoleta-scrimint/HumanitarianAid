using Centric.HumanitarianAid.API.Shelters;
using Microsoft.AspNetCore.Mvc;

namespace Centric.HumanitarianAid.API.Person
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        private readonly ShelterRepository _shelterRepository;

        public PersonsController(ShelterRepository shelterRepository)
        {
            _shelterRepository = shelterRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Get()
        {
            return Ok(_shelterRepository.GetAllPersons());
        }
    }
}