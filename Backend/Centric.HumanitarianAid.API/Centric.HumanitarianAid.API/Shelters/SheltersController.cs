using Microsoft.AspNetCore.Mvc;

namespace Centric.HumanitarianAid.API.Shelters
{
    [ApiController]
    [Route("api/[controller]")]
    public class SheltersController : ControllerBase
    {
        private readonly ShelterRepository _shelterRepository;

        public SheltersController(ShelterRepository shelterRepository)
        {
            _shelterRepository = shelterRepository;
		}

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] ShelterDto sheltorDto)
        {
            var shelter = Business.Shelter.CreateShelter(
                sheltorDto.Name, 
                sheltorDto.Address, 
                sheltorDto.NumberOfPlaces, 
                sheltorDto.OwnerName, 
                sheltorDto.OwnerEmail, 
                sheltorDto.OwnerPhone);

            if (shelter.IsSuccess) 
            {
                _shelterRepository.Add(shelter.Entity);
                return Created(nameof(Get), shelter);
            }

            return BadRequest(shelter.Error);
        }

        [HttpPost("{shelterId:guid}/persons")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RegisterFamily(Guid shelterId, [FromBody] List<PersonDto> personDtos)
        {
            var persons = personDtos.Select(p => Business.Person.CreatePerson(p.Name, p.Surname, p.Age, p.Gender));

            if (persons.Any(s => s.IsFailure))
            {
                return BadRequest(string.Join(";", persons.Select(p => p.Error)));
            }

            var shelter = _shelterRepository.GetById(shelterId);

            if (shelter == null)
            {
                return NotFound($"The shelter with identifier '{shelterId}' is not found.");
            }

            var result = shelter.RegisterFamilyToShelter(persons.Select(s => s.Entity).ToList());

            return result.IsSuccess ? NoContent() : BadRequest(result.Error);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            return Ok(_shelterRepository.GetAll());
        }
    }
}