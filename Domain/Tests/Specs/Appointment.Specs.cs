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

        [Fact]
        public void UpdateAppointmentTime()
        {
            //Arrange
            DateTime updatedAppointmentTime = DateTime.Now.AddHours(1);
            var appointment = A.Dummy<Appointment>();

            //Act
            appointment.UpdateAppointmentTime(updatedAppointmentTime);

            //Assert
            Assert.Equal(appointment.AppointmentTime, updatedAppointmentTime);

        }

        [Fact]
        public void UpdateDiagnose()
        {
            //Arrange
            var updatedDiagnose = "updated diagnose";
            var appointment = A.Dummy<Appointment>();

            //Act
            appointment.UpdateDiagnose(updatedDiagnose);

            //Assert
            Assert.Equal(appointment.Diagnose, updatedDiagnose);

        }
    }
}
