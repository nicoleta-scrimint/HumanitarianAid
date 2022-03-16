using Centric.HumanitarianAid.API.Persons;
using Centric.HumanitarianAid.Business;
using Microsoft.AspNetCore.Mvc;

namespace Centric.HumanitarianAid.API.Shelters
{
    [ApiController]
    [Route("api/[controller]")]
    public class SheltersController : ControllerBase
    {
        private static List<Shelter> _shelters = new();

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create([FromBody] CreateShelterDto sheltorDto)
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

                var entity = shelter.Entity;
                var shelterDto = new ShelterDto
                {
                    Id = entity.Id,
                    Address = entity.Address,
                    Name = entity.Name,
                    OwnerEmail = entity.OwnerEmail,
                    OwnerName = entity.OwnerName,
                    OwnerPhone = entity.OwnerPhone,
                    RegistrationDateTime = entity.RegistrationDateTime,
                    RemainingNumberOfPlaces = entity.NumberOfPlaces
                };

                return Created(nameof(Get), shelterDto);
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
            var shelters = _shelters.Select(s => new ShelterDto
            {
                Id = s.Id, 
                Address = s.Address,
                Name = s.Name,
                RemainingNumberOfPlaces = s.GetAvailableNumberOfPlaces(),
                OwnerEmail = s.OwnerEmail,
                OwnerName = s.OwnerName,
                OwnerPhone = s.OwnerPhone,
                RegistrationDateTime = s.RegistrationDateTime
            });

            return Ok(shelters);
        }
    }
}