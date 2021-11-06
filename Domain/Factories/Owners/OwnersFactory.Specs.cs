using Domain.Exceptions;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Domain.Factories.Owners
{
    public class OwnersFactorySpecs
    {
        [Fact]
        public void BuildShouldNotThrowExceptionWithValidParameters()
        {
            //Arrange
            var ownerFactory = new OwnersFactory();

            //Act
            Action owner = () => ownerFactory
                .WithName("some name")
                .WithPhoneNumber("+1224234323")
                .Build();

            //Assert
            owner.Should().NotThrow<InvalidOwnerException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionWhenNoName()
        {
            //Arrange
            var ownerFactory = new OwnersFactory();

            //Act
            Action owner = () => ownerFactory
                .WithPhoneNumber("+1224234323")
                .Build();

            //Assert
            owner.Should().Throw<InvalidOwnerException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionWhenNoPhone()
        {
            //Arrange
            var ownerFactory = new OwnersFactory();

            //Act
            Action owner = () => ownerFactory
                .WithName("some name")
                .Build();

            //Assert
            owner.Should().Throw<InvalidOwnerException>();
        }
    }
}
