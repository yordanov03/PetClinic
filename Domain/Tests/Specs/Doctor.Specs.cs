using Domain.Exceptions;
using FakeItEasy;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.Tests.Specs
{
    public class Doctor
    {
        [Fact]
        public void CreateValidDoctor()
        {
            //Arrange
            Action doctor = ()=> A.Dummy<Doctor>();

            //Assert
            doctor.Should().NotThrow<InvalidDoctorException>();

        }
    }
}
