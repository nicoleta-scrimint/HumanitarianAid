using Centric.HumanitarianAid.Business;

namespace Centric.HumanitarianAid.API.Shelters
{
    using Data;
    using Microsoft.EntityFrameworkCore;

    public class ShelterRepository
    {
        private readonly DatabaseContext databaseContext;

        public ShelterRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Shelter shelter)
        {
            this.databaseContext.Set<Shelter>().Add(shelter);
            this.databaseContext.SaveChanges();
        }

        public Shelter GetById(Guid id)
        {
            return this.databaseContext.Set<Shelter>()
                .Include(x => x.Persons)
                .SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Shelter> GetAll()
        {
            return this.databaseContext.Set<Shelter>()
                .Include(x => x.Persons)
                .ToList();
        }

        public void Save()
        {
            this.databaseContext.SaveChanges();
        }
    }
}
