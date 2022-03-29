using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Centric.HumanitarianAid.API.Persons;
using FluentAssertions;
using HumanitarianAid.API.Shelters;

using Xunit;

namespace Centric.HumanitarianAid.API.IntegrationTests
{
    public class PersonsControllerTests : BaseIntegrationTests
    {
        [Fact]
        public async Task When_GetPersons_Then_ShouldReturnPersonsFromAllShelters()
        {
            // Arrange
            var createShelterDto = new CreateShelterDto
            {
                Name = "City Hall",
                Address = "Iasi",
                NumberOfPlaces = 200,
                OwnerName = "Adrian Onu",
                OwnerEmail = "adrian.onu@email.com",
                OwnerPhone = "0756800800"
            };
            var createShelterResponse = await HttpClient.PostAsJsonAsync("api/Shelters", createShelterDto);
            createShelterResponse.EnsureSuccessStatusCode();
            var shelter = await createShelterResponse.Content.ReadFromJsonAsync<ShelterDto>();

            var persons = new List<PersonDto>
            {
                new PersonDto
                {
                    Name = "Clara",
                    Surname = "Mitrea",
                    Age = 29,
                    Gender = "Female"
                }
            };
            var registerFamilyToShelterResponse = await HttpClient.PostAsJsonAsync($"api/Shelters/{shelter.Id}/persons", persons);
            registerFamilyToShelterResponse.EnsureSuccessStatusCode();

            // Act
            var getPersonsResponse = await HttpClient.GetAsync("api/Persons");

            // Assert
            getPersonsResponse.EnsureSuccessStatusCode();
            var personsFromGetResponse = await getPersonsResponse.Content.ReadFromJsonAsync<List<Business.Person>>();
            personsFromGetResponse.Should().HaveCount(1);
        }
    }
}