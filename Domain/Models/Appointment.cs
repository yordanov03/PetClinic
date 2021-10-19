using Domain.Exceptions;
using PetClinic.Domain.Common;
using System;

namespace Domain.Models
{
    public class Appointment : Entity<int>
    {
        public Appointment(
            Doctor doctor,
            DateTime time,
            Pet pet)
        {
            Validate(time);

            this.Doctor = doctor;
            this.Time = time;
            this.Pet = pet;
        }
        public string Diagnose { get; private set; }
        public Doctor Doctor { get; private set; }
        public DateTime Time { get; private set; }
        public Pet Pet { get; private set; }

        private void Validate(DateTime time)
        {
            ValidateTime(time);
        }

        private void ValidateTime(DateTime time) =>
            Guard.ForValidTime<InvalidAppointmentException>(
                time,
                nameof(Time));
        
    }
}
