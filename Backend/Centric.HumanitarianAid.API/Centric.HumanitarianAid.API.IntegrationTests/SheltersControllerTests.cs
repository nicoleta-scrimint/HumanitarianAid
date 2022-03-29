using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Centric.HumanitarianAid.API.Persons;
using Centric.HumanitarianAid.Business;
using FluentAssertions;
using HumanitarianAid.API.Shelters;
using Xunit;

namespace Centric.HumanitarianAid.API.IntegrationTests
{
    public class SheltersControllerTests : BaseIntegrationTests
    {
        [Fact]
        public async Task When_CreateShelter_Then_ShouldReturnCreatedShelterInGetRequest()
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

            // Act
            var createShelterResponse = await HttpClient.PostAsJsonAsync("api/Shelters", createShelterDto);

            // Assert
            createShelterResponse.EnsureSuccessStatusCode();
            createShelterResponse.StatusCode.Should().Be(HttpStatusCode.Created);
            var shelter = await createShelterResponse.Content.ReadFromJsonAsync<ShelterDto>();
            shelter.Should().NotBeNull();

            var getSheltersResponse = await HttpClient.GetAsync("api/Shelters");
            getSheltersResponse.EnsureSuccessStatusCode();
            var shelters = await getSheltersResponse.Content.ReadFromJsonAsync<List<Shelter>>();
            shelters.Should().NotBeNull();
            shelters.Should().HaveCount(1);
        }

        [Fact]
        public async Task When_RegisterFamilyToShelter_Then_ShouldGetPersonsInChangedShelter()
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
            shelter.Should().NotBeNull();
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

            // Act
            var registerFamilyToShelterResponse = await HttpClient.PostAsJsonAsync($"api/Shelters/{shelter.Id}/persons", persons);

            // Assert
            registerFamilyToShelterResponse.EnsureSuccessStatusCode();
            registerFamilyToShelterResponse.StatusCode.Should().Be(HttpStatusCode.NoContent);

            var getSheltersResponse = await HttpClient.GetAsync("api/Shelters");
            getSheltersResponse.EnsureSuccessStatusCode();
            var shelters = await getSheltersResponse.Content.ReadFromJsonAsync<List<ShelterDto>>();
            shelters.Should().NotBeNull();
            shelters.Should().HaveCount(1);
        }
    }
}