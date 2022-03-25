using Centric.HumanitarianAid.API.Persons;
using Centric.HumanitarianAid.Business;
using Microsoft.AspNetCore.Mvc;

namespace HumanitarianAid.API.Shelters
{
    [ApiController]
    [Route("api/[controller]")]
    public class SheltersController : ControllerBase
    {
        private readonly ShelterRepository _shelterRepository;
        private readonly PersonRepository _personRepository;

        public SheltersController(ShelterRepository shelterRepository,
            PersonRepository personRepository)
        {
            _shelterRepository = shelterRepository;
            _personRepository = personRepository;
        }

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
                _shelterRepository.Add(shelter.Entity);

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
            var persons = personDtos
                .Select(p => Person.CreatePerson(p.Name, p.Surname, p.Age, p.Gender))
                .ToList();

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

            persons.ForEach(x => _personRepository.Add(x.Entity));
            _shelterRepository.Save();

            return result.IsSuccess ? NoContent() : BadRequest(result.Error);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var shelters = _shelterRepository.GetAll()
                .Select(x => new ShelterDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Address = x.Address,
                    RemainingNumberOfPlaces = x.GetAvailableNumberOfPlaces(),
                    NumberOfPlaces = x.NumberOfPlaces,
                    OwnerName = x.OwnerName,
                    OwnerEmail = x.OwnerEmail,
                    OwnerPhone = x.OwnerPhone,
                    RegistrationDateTime = x.RegistrationDateTime
                });

            return Ok(shelters);
        }

        [HttpGet("shelterId:guid")]
        public IActionResult GetById(Guid shelterId)
        {
            var shelter = _shelterRepository.GetById(shelterId);

            if (shelter == null)
            {
                return NotFound($"Shelter with id {shelterId} not found.");
            }

            return Ok(shelter);
        }

        [HttpDelete("shelterId")]
        public IActionResult Delete(Guid shelterId)
        {
            var shelter = _shelterRepository.GetById(shelterId);
            if (shelter == null)
            {
                return NotFound($"Shelter with id {shelterId} not found.");
            }

            _shelterRepository.Delete(shelter);

            return NoContent();
        }

        [HttpPut("shelterId")]
        public IActionResult Update(Guid shelterId, [FromBody] UpdateShelterDto shelterDto)
        {
            var shelter = _shelterRepository.GetById(shelterId);

            if (shelter == null)
            {
                return NotFound($"Shelter with id {shelterId} not found.");
            }

            var result = shelter.UpdateShelter(
                shelterDto.Name, 
                shelterDto.Address, 
                shelterDto.NumberOfPlaces, 
                shelterDto.OwnerName, 
                shelterDto.OwnerEmail, 
                shelterDto.OwnerPhone);

            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            _shelterRepository.Update(result.Entity);

            return NoContent();
        }
    }
}