using Domain.Exceptions;
using PetClinic.Domain.Common;
using System;

namespace Domain.Models
{
    public class Appointment : Entity<int>, IAggregateRoot
    {
        public Appointment(
            string title,
            string diagnose,
            DateTime appointmentTime,
            Pet pet)
        {
            Validate(title, appointmentTime);

            this.Title = title;
            this.Diagnose = diagnose;
            this.AppointmentTime = appointmentTime;
            this.Pet = pet;
        }

        private Appointment(
            string title,
           string diagnose,
           DateTime appointmentTime)
        {
            this.Title = title;
            this.Diagnose = diagnose;
            this.AppointmentTime = appointmentTime;
            this.Pet = default!;
        }

        public string Title { get; private set; }
        public string Diagnose { get; private set; }
        public DateTime AppointmentTime { get; private set; }
        public Pet Pet { get; private set; }

        private void Validate(string title, DateTime time)
        {
            ValidateTitle(title);
            ValidateTime(time);
        }

        private void ValidateTitle(string title) =>
            Guard.AgainstEmptyString<InvalidAppointmentException>(
                title,
                nameof(Title));

        private void ValidateTime(DateTime time) =>
            Guard.ForValidTime<InvalidAppointmentException>(
                time,
                nameof(AppointmentTime));

        private void ValidateDiagnose(string diagnose) =>
            Guard.AgainstEmptyString<InvalidAppointmentException>(
                diagnose,
                nameof(Diagnose));


        public Appointment UpdateAppointmentTime(DateTime time)
        {
            ValidateTime(time);
            this.AppointmentTime = time;
            return this;
        }

        public Appointment UpdateDiagnose(string diagnose)
        {
            ValidateDiagnose(diagnose);
            this.Diagnose = diagnose;
            return this;
        }

    }
}
