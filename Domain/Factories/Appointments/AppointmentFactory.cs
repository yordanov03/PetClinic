using Domain.Exceptions;
using Domain.Models;
using System;

namespace Domain.Factories.Appointments
{
    internal class AppointmentFactory : IAppointmentFactory
    {
        private string appointmentTitle = default!;
        private string appointmentDiagnose = default!;
        private DateTime scheduledAppointmentTime = default!;
        private Pet pet = default!;

        private bool petSet = false;

        public Appointment Build()
        {
            if (!this.petSet)
            {
                throw new InvalidAppointmentException("Pet must have a value!");
            }

            return new Appointment(
                this.appointmentTitle,
                this.appointmentDiagnose,
                this.scheduledAppointmentTime,
                this.pet);
        }

        public IAppointmentFactory WithAppointmentTime(DateTime appointmentTime)
        {
            this.scheduledAppointmentTime = appointmentTime;
            return this;
        }

        public IAppointmentFactory WithDiagnose(string diagnose)
        {
            this.appointmentDiagnose = diagnose;
            return this;
        }

        public IAppointmentFactory WithPet(Pet pet)
        {
            this.pet = pet;
            this.petSet = true;
            return this;
        }

        public IAppointmentFactory WithTitle(string title)
        {
            this.appointmentTitle = title;
            return this;
        }
    }
}
