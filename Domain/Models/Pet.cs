using CarRentalSystem.Domain.Common;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Pet : Entity<int>, IAggregateRoot
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Spicie Spicie{ get; private set; }
        public Owner Owner { get; private set; }
        public string Picutre { get; private set; }
        public List<Appointment> MedicalHisotry { get; private set; }
        public Doctor Doctor { get; private set; }
    }
}
