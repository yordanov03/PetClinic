using Domain.Exceptions;
using PetClinic.Domain.Common;
using System;

namespace Domain.Models
{
    public class Appointment : Entity<int>
    {
        public Appointment(
            string diagnose,
            DateTime appointmentTime,
            Pet pet)
        {
            Validate(appointmentTime);

            this.Diagnose = diagnose;
            this.AppointmentTime = appointmentTime;
            this.Pet = pet;
        }
        public string Diagnose { get; private set; }
        public DateTime AppointmentTime { get; private set; }
        public Pet Pet { get; private set; }

        private void Validate(DateTime time)
        {
            ValidateTime(time);
        }

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
