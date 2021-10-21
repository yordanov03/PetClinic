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
    }
}
