using Centric.HumanitarianAid.Business;
using Microsoft.AspNetCore.Mvc;

namespace Centric.HumanitarianAid.API.Shelters
{
    [ApiController]
    [Route("api/[controller]")]
    public class SheltersController : ControllerBase
    {
        private static List<Shelter> _shelters = new List<Shelter>();

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] ShelterDto sheltorDto)
        {
            var shelter = Shelter.CreateShelter(
                sheltorDto.Name, 
                sheltorDto.Address, 
                sheltorDto.NumberOfPlaces, 
                sheltorDto.OwnerName, 
                sheltorDto.OwnerEmail, 
                sheltorDto.OwnerPhone);

            if (shelter.IsSuccess) 
            {
                _shelters.Add(shelter.Entity);
                return Ok(_shelters); // Just for testing purposes, if no message should be returned to client, then NoContent. In fact it should be Created, but I'm following the specs:))
            }

            return BadRequest(shelter.Error);
        }

        [HttpPost("{shelterId:guid}/persons")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult RegisterFamily(Guid shelterId, [FromBody] List<PersonDto> personDtos)
        {
            var persons = personDtos.Select(p => Person.CreatePerson(p.Name, p.Surname, p.Age, p.Gender));

            if (persons.Any(s => s.IsFailure))
            {
                return BadRequest(string.Join(";", persons.Select(p => p.Error)));
            }

            var shelter = _shelters.FirstOrDefault(s => s.Id == shelterId);

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
            return Ok(_shelters);
        }

        [HttpGet("{shelterId:guid}/persons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetPersons(Guid shelterId)
        {
            var shelter = _shelters.FirstOrDefault(s => s.Id == shelterId);

            if (shelter == null)
            {
                return NotFound($"The shelter with identifier '{shelterId}' is not found.");
            }

            return Ok(shelter.Persons);
        }
    }
}