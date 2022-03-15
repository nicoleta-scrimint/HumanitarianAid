﻿namespace Centric.HumanitarianAid.Business
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }

        public int Age { get; private set; }

        public PersonGender Gender { get; private set; }

        public Guid? ShelterId { get; private set; }

        public static Result<Person> CreatePerson(string name, string surname, int age, string gender)
        {
            if (!Enum.TryParse<PersonGender>(gender, out var personGender))
            {
                var textExpectedGenderValues = string.Join(",", Enum.GetNames(typeof(PersonGender)));
                return Result<Person>.Failure($"The person gender can be one from the values '{textExpectedGenderValues}'.");
            }

            var person = new Person()
            {
                Id = Guid.NewGuid(),
                Name = name,
                Surname = surname,
                Age = age,
                Gender = personGender,
                ShelterId = null
            };
            return Result<Person>.Success(person);
        }

        public void RegisterPersonToShelter(Shelter shelter)
        {
            ShelterId = shelter.Id;
        }
    }
}