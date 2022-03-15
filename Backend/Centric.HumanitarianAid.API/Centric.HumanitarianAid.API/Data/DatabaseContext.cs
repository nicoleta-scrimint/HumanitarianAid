namespace Centric.HumanitarianAid.API.Data
{
    using Business;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseContext : DbContext
    {
        public DbSet<Shelter> Shelters { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=[AbsoluteFolderPath]\\SHELTER.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var appleShelter = Shelter.CreateShelter(
                    "Apple", "Apple Avenue", 100, "Mr. Apple", "apple@apple.com", "0712345678"
                )
                .Entity;
            var cinnamonShelter = Shelter.CreateShelter(
                    "Cinnamon", "Cinnamon Avenue", 200, "Mr. Cinnamon", "cinnamon@cinnamon.com", "0712345678"
                )
                .Entity;

            modelBuilder.Entity<Shelter>().HasData(new List<Shelter>
            {
                appleShelter,
                cinnamonShelter
            });
        }
    }
}
