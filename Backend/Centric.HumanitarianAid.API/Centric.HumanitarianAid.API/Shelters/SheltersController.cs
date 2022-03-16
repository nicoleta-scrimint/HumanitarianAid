namespace Centric.HumanitarianAid.API.Shelters
{
    using Business;
    using Persons;
    using Microsoft.AspNetCore.Mvc;

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
                    OwnerName = x.OwnerName,
                    OwnerEmail = x.OwnerEmail,
                    OwnerPhone = x.OwnerPhone,
                    RegistrationDateTime = x.RegistrationDateTime
                });

            return Ok(shelters);
        }
    }
}