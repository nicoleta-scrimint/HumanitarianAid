using Centric.HumanitarianAid.Business;

namespace Centric.HumanitarianAid.API.Shelters
{
    public class ShelterRepository
    {
        private static List<Shelter> _shelters = new List<Shelter>();

        public void Add(Shelter shelter)
        {
            _shelters.Add(shelter);
        }

        public Shelter GetById(Guid id) 
        {
            return _shelters.FirstOrDefault(s => s.Id == id);
        }

        public IEnumerable<Shelter> GetAll() 
        {
            return _shelters;
        }

        public IEnumerable<Business.Person> GetAllPersons() 
        {
            return _shelters.SelectMany(s=> s.Persons);
		}
    }
}
