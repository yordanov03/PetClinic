using Domain.Exceptions;
using Domain.Models;
using FakeItEasy;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.Tests.Specs
{
    public class OwnerSpecs
    {
        [Fact]
        public void CreateValidOwner()
        {
            //Arrange
            Action owner = () => A.Dummy<Owner>();

            //Assert
            owner.Should().NotThrow<InvalidOwnerException>();
        }

        [Fact]
        public void UpdatePhoneNumber()
        {
            //Arrange
            var owner = A.Dummy<Owner>();
            var updatedPhoneNumber = "+98766576732";

            //Act
            owner.UpdatePhoneNumber(updatedPhoneNumber);

            //Assert
            Assert.Equal(owner.PhoneNumber, updatedPhoneNumber);
        }
    }
}
