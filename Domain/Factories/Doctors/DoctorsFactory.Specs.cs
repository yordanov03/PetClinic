using Domain.Exceptions;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.Factories.Doctors
{
    public class DoctorsFactorySpecs
    {
        [Fact]
        public void BuildShouldNotTHrowExceptionWhenParametersValid()
        {
            //Arrange
            var doctorsFactory = new DoctorsFactory();

            //Act
            Action act = () => doctorsFactory
            .WithName("some doctor")
            .Build();

            //Assert
            act.Should().NotThrow<InvalidDoctorException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionWhenNameNotSet()
        {
            //Arrange
            var doctorsFactory = new DoctorsFactory();

            //Act
            Action act = () => doctorsFactory
            .Build();

            //Assert
            act.Should().Throw<InvalidDoctorException>();
        }
    }
}
