using PetClinic.Domain.Common;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Doctor : Entity<int>
    {
        public string Name { get; private set; }
        public List<Pet> Patients { get; private set; }
        public List<Appointment> Appointments { get; private set; }
    }
}
