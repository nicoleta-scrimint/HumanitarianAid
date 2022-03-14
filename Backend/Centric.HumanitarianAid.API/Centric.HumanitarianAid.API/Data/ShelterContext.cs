namespace Centric.HumanitarianAid.API.Data
{
    using Business;
    using Microsoft.EntityFrameworkCore;

    public class ShelterContext : DbContext
    {
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<Person> Persons { get; set; }
    }
}
