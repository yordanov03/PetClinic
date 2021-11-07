using Domain.Exceptions;
using Domain.Models;
using FakeItEasy;
using FluentAssertions;
using System;
using Xunit;

namespace Domain.Factories.Appointments
{
    public class AppointmentFactorySpecs
    {
        [Fact]
        public void BuildShouldNotThrowExceptionWhenAllParametersAreValid()
        {
            //Arrange
            var appointmentFactory = new AppointmentsFactory();

            //Act
            Action act = () => appointmentFactory
            .WithTitle("routine check up")
            .WithAppointmentTime(DateTime.Now)
            .WithDiagnose("")
            .WithPet(A.Dummy<Pet>())
            .Build();

            //Assert
            act.Should().NotThrow<InvalidAppointmentException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionWhenTitleNotSet()
        {
            //Arrange
            var appointmentFactory = new AppointmentsFactory();

            //Act
            Action act = () => appointmentFactory
            .WithAppointmentTime(DateTime.Now)
            .WithDiagnose("some diagnose")
            .WithPet(A.Dummy<Pet>())
            .Build();

            //Assert
            act.Should().Throw<InvalidAppointmentException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionWhenTimeNotSet()
        {
            //Arrange
            var appointmentFactory = new AppointmentsFactory();

            //Act
            Action act = () => appointmentFactory
            .WithTitle("routine check up")
            .WithDiagnose("")
            .WithPet(A.Dummy<Pet>())
            .Build();

            //Assert
            act.Should().Throw<InvalidAppointmentException>();
        }

        [Fact]
        public void BuildShouldThrowExceptionWhenPetNotSet()
        {
            //Arrange
            var appointmentFactory = new AppointmentsFactory();

            //Act
            Action act = () => appointmentFactory
            .WithAppointmentTime(DateTime.Now)
            .WithDiagnose("some diagnose")
            .Build();

            //Assert
            act.Should().Throw<InvalidAppointmentException>();
        }
    }
}
