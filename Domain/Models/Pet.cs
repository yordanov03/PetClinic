using CarRentalSystem.Domain.Common;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Models
{
    public class Pet : Entity<int>, IAggregateRoot
    {
        private readonly List<Appointment> medicalHistory;
        public Pet(
            string name,
            int age,
            Spicie spicie,
            Owner owner,
            string picture,
            Doctor doctor)
        {
            this.Name = name;
            this.Age = age;
            this.Spicie = spicie;
            this.Owner = owner;
            this.Picutre = picture;
            this.medicalHistory = new List<Appointment>();
            this.Doctor = doctor;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Spicie Spicie{ get; private set; }
        public Owner Owner { get; private set; }
        public string Picutre { get; private set; }
        public Doctor Doctor { get; private set; }
        public IReadOnlyCollection<Appointment> MedicalHistory => this.medicalHistory.ToList().AsReadOnly();
    }
}
