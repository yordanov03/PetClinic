using Domain.Exceptions;
using Domain.Models;
using FakeItEasy;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.Tests.Specs
{
    public class PetSpecs
    {
        [Fact]
        public void CreatePetSuccessfully()
        {
            //Arrange
            Action pet = () => A.Dummy<Pet>();

            //Act
            pet.Should().NotThrow<InvalidPetException>();
        }

        [Fact]
        public void UpdateAge()
        {
            //Arrange
            var pet = A.Dummy<Pet>();
            int updatedAge = 6;

            //Act
            pet.UpdateAge(updatedAge);

            //Assert
            Assert.Equal(pet.Age, updatedAge);
        }

        [Fact]
        public void UpdatePicture()
        {
            //Arrange
            var pet = A.Dummy<Pet>();
            var updatedPictureUrl = "https://i.natgeofe.com/n/f0dccaca-174b-48a5-b944-9bcddf913645/01-cat-questions-nationalgeographic_1228126.jpg";

            //Act
            pet.UpdatePicture(updatedPictureUrl);

            //Assert
            Assert.Equal(pet.Picutre, updatedPictureUrl);
        }
    }
}
