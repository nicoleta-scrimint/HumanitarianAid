namespace Centric.HumanitarianAid.Business
{
    public class Person
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public int Age { get; private set; }

        public PersonGender Gender { get; private set; }

        public Guid ShelterId { get; private set; }

        public Shelter Shelter { get; set; }

        public static Result<Person> CreatePerson(string name, string surname, int age, string gender)
        {
            if (!Enum.TryParse<PersonGender>(gender, out var personGender))
            {
                var expectedGenderValues = Enum.GetValues(typeof(PersonGender)).Cast<string>();
                var textExpectedGenderValues = string.Join<string>(",", expectedGenderValues);
                return Result<Person>.Failure($"The person gender can be one from the values '{textExpectedGenderValues}'.");
            }

            var person = new Person()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Surname = surname,
                Age = age,
                Gender = personGender
            };
            return Result<Person>.Success(person);
        }

        public void RegisterPersonToShelter(Shelter shelter)
        {
            Shelter = shelter;
            ShelterId = shelter.Id;
        }
    }
}