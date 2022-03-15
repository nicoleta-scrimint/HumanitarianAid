using FluentAssertions;
using Xunit;

namespace Centric.HumanitarianAid.Business.UnitTests
{
    public class PersonTests
    {
        [Fact]
        public void When_CreatePerson_Then_ShouldReturnPerson()
        {
            // Arrange
            var name = "Mitrea";
            var surName = "Cristian";
            var age = 36;
            var gender = "Male";

            // Act
            var result = Person.CreatePerson(name, surName, age, gender);

            // Assert
            result.IsSuccess.Should().BeTrue();
            result.Entity.Should().NotBeNull();
            result.Entity.Name.Should().Be(name);
            result.Entity.Surname.Should().Be(surName);
            result.Entity.Age.Should().Be(age);
            result.Entity.Gender.Should().Be(PersonGender.Male);
        }

        [Fact]
        public void When_CreatePersonWithInvalidGender_Then_ShouldReturnFailure()
        {
            // Arrange
            var name = "Mitrea";
            var surName = "Cristian";
            var age = 36;
            var gender = "Males";

            // Act
            var result = Person.CreatePerson(name, surName, age, gender);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("The provided person gender 'Males' is not one from the values 'Male, Female, Other'.");
        }
    }
}