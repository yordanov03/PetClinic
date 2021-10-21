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
        public void CreatePEtSuccessfully()
        {
            //Arrange
            Action pet = () => A.Dummy<Pet>();

            //Act
            pet.Should().NotThrow<InvalidPetException>();
        }
    }
}
