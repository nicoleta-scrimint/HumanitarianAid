namespace Centric.HumanitarianAid.Business
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Shelter
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Address { get; private set; }

        public int NumberOfPlaces { get; private set; }

        public string OwnerName { get; private set; }

        public string OwnerEmail { get; private set; }

        public string OwnerPhone { get; private set; }
        
        public DateTime RegistrationDateTime { get; private set; }

        public List<Person> Persons { get; private set; }

        public static Result<Shelter> CreateShelter(string name, string address, int numberOfPlaces, string ownerName, string ownerEmail, string ownerPhone)
        {
            var minimumNumberOfPlaces = 0;
            if (numberOfPlaces <= 0)
            {
                return Result<Shelter>.Failure($"The number of places for the shelter needs to be greater than {minimumNumberOfPlaces}.");
            }

            var shelter = new Shelter
            {
                Id = Guid.NewGuid(),
                Name = name,
                Address = address,
                NumberOfPlaces = numberOfPlaces,
                OwnerName = ownerName,
                OwnerEmail = ownerEmail,
                OwnerPhone = ownerPhone,
                RegistrationDateTime = DateTime.Now,
                Persons = new List<Person>()
            };
            return Result<Shelter>.Success(shelter);
        }

        public Result RegisterFamilyToShelter(List<Person> persons)
        {
            if (!persons.Any())
            {
                return Result.Failure("Add at least a person to the shelter.");
            }

            if (persons.Count > GetAvailableNumberOfPlaces())
            {
                return Result.Failure($"The newly added persons number '{persons.Count}' exceed the available number of places: '{GetAvailableNumberOfPlaces()}'");
            }
            
            persons.ForEach(person =>
            {
                person.RegisterPersonToShelter(this);
                Persons.Add(person);
            });
            
            return Result.Success();
        }

        public int GetAvailableNumberOfPlaces()
        {
            return NumberOfPlaces - Persons.Count;
        }
    }
}