# HumanitarianAid

**Step 3 - Persistence**

## 1.Instalare library necesare 
  In *Tools -> NuGet Package Manager -> Manage NuGet Packages For Solution* cautam Microsoft.EntityFramework si instalam urmatoarele pachete in proiectul Centric.HumanitarianAid.API: 
* Microsoft.EntityFrameworkCore 
* Microsoft.EntityFrameworkCore.SqlServer(pentru provider) 
* Microsoft.EntityFrameworkCore.Tools(pentru a executa comenzi) 
* Microsoft.EntityFrameworkCore.Design(pentru a activa interactiuni la design-time: migrations)

## 2.Creare context
 * Cream un folder nou numit Data si in el o clasa noua DatabaseContexts.cs
 * Derivam DatabaseContext din DbContext
 * Adăugam o proprietate DbSet pentru entitatile Shelter si Person si anume: *public DbSet<Shelter> Shelter { get; set; } public DbSet<Person> Person { get; set; }*
 * Pentru a avea date initiale de Shelters am folosit metoda .HasData()
 * Adaugam DatabaseContext in lista de servicii scoped in Program.cs
  
## 3. Setare conexiune la baza de date
  * Facem override la metoda *OnConfiguring* si setam link-ul de conexiune la baza de date: *"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=[AbsoluteFolderPath]\\SHELTER.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"*
  * In clasele Shelter si Person, setam atributele pentru cheile primare: *[Key]* si *[DatabaseGenerated(DatabaseGeneratedOption.Identity)]*
  
  ## 4.Dacă nu este deja facuta automat (din constructorul de DatabaseContext), adaugam prima migrare la baza de date astfel:
 * Deschidem Package Manager Console (*Tools -> Nuget Package Manager -> Package Manager Console*)
 * Rulam Add-Migration Init, sau orice alt nume pentru migrare, dar trebuie sa fie sugestiv (ne asiguram ca proiectul Centric.HumanitarianAid.API este setat ca Start up project) 
 * Rulam Update-Database.
Apoi verificam in Sql Server Object Explorer/Server Explorer ca baza de date s-a creat cu success.
  
  ## 5.Creare repository
 * In constructorul clasei ShelterRepository injectam DatabaseContext
 * Cream o metoda Get care returnează toata lista de adaposturi din baza de date
 * Se apeleaza contextul astfel: _dbContext.Set<Shelter>().AsEnumerable();
 * Adaugam si medoda de add care adauga un adapost in baza de date. Putem extinde functionalitatea cu metode de editare, cautare dupa id si alte metode utile. 
 Cand se executa comenzi trebuie sa tinem minte sa apelam si SaveChanges pe context.
 La fel procedam si pentru Persons.

## 6.Ne asiguram ca in controller folosim ambele repositories.
 * Apelam metodele din repository
 
Accesand swagger putem verifica conexiunea la baza de date: rulam applicatia si accesam ' /swagger '.
