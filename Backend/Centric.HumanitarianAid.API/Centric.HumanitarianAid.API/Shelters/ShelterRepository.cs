using Centric.HumanitarianAid.API.Data;
using Centric.HumanitarianAid.Business;
using Microsoft.EntityFrameworkCore;

namespace HumanitarianAid.API.Shelters;

    public class ShelterRepository
    {
        private readonly DatabaseContext _databaseContext;

        private DbSet<Shelter> Table => _databaseContext.Set<Shelter>();

        public ShelterRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Add(Shelter shelter)
        {
            Table.Add(shelter);
            Save();
        }

        public Shelter GetById(Guid id)
        {
            return Table
                .Include(x => x.Persons)
                .SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<Shelter> GetAll()
        {
            return Table
                .Include(x => x.Persons)
                .ToList();
        }

        public void Delete(Shelter shelter)
        {
            shelter.Persons.Clear();
            Table.Remove(shelter);
            Save();
        }

        public void Update(Shelter shelter)
        {
            Table.Update(shelter);
            Save();
        }

        public void Save()
        {
            _databaseContext.SaveChanges();
        }
    }