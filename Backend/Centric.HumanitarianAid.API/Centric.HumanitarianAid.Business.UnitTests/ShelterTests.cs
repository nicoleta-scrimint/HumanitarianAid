using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Centric.HumanitarianAid.Business.UnitTests
{
    public class ShelterTests
    {
        [Fact]
        public void When_CreateShelter_Then_ShouldReturnEntity()
        {
            // Arrange
            var name = "Centru refugiati 1";
            var address = "Iasi";
            var numberOfPlaces = 50;
            var ownerName = "Cristian Mitrea";
            var ownerEmail = "cristian.mitrea@email.com";
            var ownerPhone = "0744100100";

            // Act
            var shelter = Shelter.CreateShelter(name, address, numberOfPlaces, ownerName, ownerEmail, ownerPhone);

            // Assert
            shelter.IsSuccess.Should().BeTrue();
            shelter.Entity.Should().NotBeNull();
            shelter.Entity.Name.Should().Be(name);
            shelter.Entity.Address.Should().Be(address);
            shelter.Entity.NumberOfPlaces.Should().Be(numberOfPlaces);
            shelter.Entity.OwnerName.Should().Be(ownerName);
            shelter.Entity.OwnerEmail.Should().Be(ownerEmail);
            shelter.Entity.OwnerPhone.Should().Be(ownerPhone);
            shelter.Entity.RegistrationDateTime.Date.Should().Be(DateTime.Today);
            shelter.Entity.Persons.Should().NotBeNull();
            shelter.Entity.Persons.Should().BeEmpty();
        }

        [Fact]
        public void When_CreateShelterWithZeroNumberOfPlaces_Then_ShouldReturnError()
        {
            // Arrange
            var name = "Centru refugiati 1";
            var address = "Iasi";
            var numberOfPlaces = 0;
            var ownerName = "Cristian Mitrea";
            var ownerEmail = "cristian.mitrea@email.com";
            var ownerPhone = "0744100100";

            // Act
            var shelter = Shelter.CreateShelter(name, address, numberOfPlaces, ownerName, ownerEmail, ownerPhone);

            // Assert
            shelter.IsFailure.Should().BeTrue();
            shelter.Error.Should().Be("The number of places for the shelter needs to be greater than 0.");
        }

        [Fact]
        public void When_CreateShelterWithNumberOfPlacesSmallerThanZero_Then_ShouldReturnError()
        {
            // Arrange
            var name = "Centru refugiati 1";
            var address = "Iasi";
            var numberOfPlaces = -2;
            var ownerName = "Cristian Mitrea";
            var ownerEmail = "cristian.mitrea@email.com";
            var ownerPhone = "0744100100";

            // Act
            var shelter = Shelter.CreateShelter(name, address, numberOfPlaces, ownerName, ownerEmail, ownerPhone);

            // Assert
            shelter.IsFailure.Should().BeTrue();
            shelter.Error.Should().Be("The number of places for the shelter needs to be greater than 0.");
        }

        [Fact]
        public void When_RegisterFamilyToShelterWithPersons_Then_ShouldReturnSuccess()
        {
            // Arrange
            var name = "Centru refugiati 1";
            var address = "Iasi";
            var numberOfPlaces = 2;
            var ownerName = "Cristian Mitrea";
            var ownerEmail = "cristian.mitrea@email.com";
            var ownerPhone = "0744100100";
            var shelter = Shelter.CreateShelter(name, address, numberOfPlaces, ownerName, ownerEmail, ownerPhone);
            var persons = new List<Person>
            {
                Person.CreatePerson("Cretu", "Dorin", 25, "Male").Entity,
                Person.CreatePerson("Trusescu", "Oana", 43, "Female").Entity
            };

            // Act
            var result = shelter.Entity.RegisterFamilyToShelter(persons);

            // Assert
            result.IsSuccess.Should().BeTrue();
        }

        [Fact]
        public void When_RegisterFamilyToShelterWithPersons_Then_ShouldReturnZeroAvailableNumberOfPlaces()
        {
            // Arrange
            var name = "Centru refugiati 1";
            var address = "Iasi";
            var numberOfPlaces = 2;
            var ownerName = "Cristian Mitrea";
            var ownerEmail = "cristian.mitrea@email.com";
            var ownerPhone = "0744100100";
            var shelter = Shelter.CreateShelter(name, address, numberOfPlaces, ownerName, ownerEmail, ownerPhone);
            var persons = new List<Person>
            {
                Person.CreatePerson("Cretu", "Dorin", 25, "Male").Entity,
                Person.CreatePerson("Trusescu", "Oana", 43, "Female").Entity
            };

            // Act
            shelter.Entity.RegisterFamilyToShelter(persons);
            var availableNumberOfPlaces = shelter.Entity.GetAvailableNumberOfPlaces();

            // Assert
            availableNumberOfPlaces.Should().Be(0);
        }

        [Fact]
        public void When_GetAvailableNumberOfPlacesWithoutRegisteredPersons_Then_ShouldReturnShelterNumberOfPlaces()
        {
            // Arrange
            var name = "Centru refugiati 1";
            var address = "Iasi";
            var numberOfPlaces = 2;
            var ownerName = "Cristian Mitrea";
            var ownerEmail = "cristian.mitrea@email.com";
            var ownerPhone = "0744100100";
            var shelter = Shelter.CreateShelter(name, address, numberOfPlaces, ownerName, ownerEmail, ownerPhone);

            // Act
            var availableNumberOfPlaces = shelter.Entity.GetAvailableNumberOfPlaces();

            // Assert
            availableNumberOfPlaces.Should().Be(2);
        }

        [Fact]
        public void When_RegisterFamilyToShelterWithoutPersons_Then_ShouldReturnFailure()
        {
            // Arrange
            var name = "Centru refugiati 1";
            var address = "Iasi";
            var numberOfPlaces = 2;
            var ownerName = "Cristian Mitrea";
            var ownerEmail = "cristian.mitrea@email.com";
            var ownerPhone = "0744100100";
            var shelter = Shelter.CreateShelter(name, address, numberOfPlaces, ownerName, ownerEmail, ownerPhone);
            var persons = new List<Person>();

            // Act
            var result = shelter.Entity.RegisterFamilyToShelter(persons);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("Add at least a person to the shelter.");
        }

        [Fact]
        public void When_RegisterFamilyToShelterWithNumberOfPersonsGreaterThanAvailableNumberOfPlaces_Then_ShouldReturnFailure()
        {
            // Arrange
            var name = "Centru refugiati 1";
            var address = "Iasi";
            var numberOfPlaces = 1;
            var ownerName = "Cristian Mitrea";
            var ownerEmail = "cristian.mitrea@email.com";
            var ownerPhone = "0744100100";
            var shelter = Shelter.CreateShelter(name, address, numberOfPlaces, ownerName, ownerEmail, ownerPhone);
            var persons = new List<Person>
            {
                Person.CreatePerson("Cretu", "Dorin", 25, "Male").Entity,
                Person.CreatePerson("Trusescu", "Oana", 43, "Female").Entity
            };

            // Act
            var result = shelter.Entity.RegisterFamilyToShelter(persons);

            // Assert
            result.IsFailure.Should().BeTrue();
            result.Error.Should().Be("The newly added persons number '2' exceed the available number of places: '1'");
        }
    }
}