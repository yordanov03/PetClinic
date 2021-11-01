using Domain.Exceptions;
using PetClinic.Domain.Common;
using System.Collections.Generic;
using System.Linq;
using static PetClinic.Domain.Models.ModelConstants.Common;

namespace Domain.Models
{
    public class Doctor : Entity<int>, IAggregateRoot
    {
        private readonly List<Appointment> appointments;
        private readonly List<Pet> patients;

        public Doctor(string name)
        {
            Validate(name);

            this.Name = name;
            this.patients = new List<Pet>();
            this.appointments = new List<Appointment>();
        }
        public string Name { get; private set; }
        public IReadOnlyCollection<Pet> Patients => this.patients.ToList().AsReadOnly();
        public IReadOnlyCollection<Appointment> Appointments => this.appointments.ToList().AsReadOnly();

        private void Validate(string name)
        {
            ValidateName(name);
        }

        private void ValidateName(string name) =>
            Guard.ForStringLength<InvalidDoctorException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(Name));

        public void AddAppointment(Appointment appointment) => this.appointments.Add(appointment);

        public void AssignPetToDoctor(Pet pet) => this.patients.Add(pet);
    }
}
