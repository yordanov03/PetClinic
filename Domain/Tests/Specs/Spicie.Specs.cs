using Domain.Exceptions;
using Domain.Models;
using FakeItEasy;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.Tests.Specs
{
    public class SpicieSpecs
    {
        [Fact]
        public void SpicieShouldNotThrowException()
        {
            //Arrange
            Action spicie = () => A.Dummy<Spicie>();

            //Assert
            spicie.Should().NotThrow<InvalidPetException>();
        }

        [Fact]
        public void InvalidNameShouldThrowException()
        {
            //Arrange
            Action spicie = () => new Spicie("");

            //Assert
            spicie.Should().Throw<InvalidPetException>();

        }
    }
}
