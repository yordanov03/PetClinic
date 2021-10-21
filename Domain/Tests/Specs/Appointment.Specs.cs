using Domain.Models;
using FakeItEasy;
using Xunit;
using FluentAssertions;
using System;
using Domain.Exceptions;

namespace Domain.Tests
{
    public class AppointmentSpecs
    {
        [Fact]
        public void CreateValidAppointment()
        {
            //Arrange
            Action appointment = () => A.Dummy<Appointment>();

            //Assert
            appointment.Should().NotThrow<InvalidAppointmentException>();
        }
    }
}
