namespace Centric.HumanitarianAid.API.Person
{
    using Business;
    using Data;

    public class PersonRepository
	{
        private readonly DatabaseContext databaseContext;

        public PersonRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public void Add(Person person)
        {
            this.databaseContext.Set<Person>().Add(person);
            this.databaseContext.SaveChanges();
        }

        public IEnumerable<Person> GetAll()
        {
            return this.databaseContext.Set<Person>();
        }
    }
}
