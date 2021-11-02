using Domain.Exceptions;
using Domain.Models;
using FakeItEasy;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.Tests.Specs
{
    public class DoctorSpecs
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
