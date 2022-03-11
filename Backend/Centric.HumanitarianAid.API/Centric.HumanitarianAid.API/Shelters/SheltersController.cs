using Microsoft.AspNetCore.Mvc;

namespace Centric.HumanitarianAid.API.Shelters
{
    [ApiController]
    [Route("[controller]")]
    public class SheltersController : ControllerBase
    {
        private readonly ILogger<SheltersController> _logger;
        private readonly ShelterRepository _shelterRepository;

        public SheltersController(ILogger<SheltersController> logger, ShelterRepository shelterRepository)
        {
            _logger = logger;
            _shelterRepository = shelterRepository;
        }

        [HttpGet()]
        public ICollection<ShelterDto> Get()
        {
            return Enumerable.Range(1, 5).Select(_ => new ShelterDto()).ToArray();
        }
    }
}