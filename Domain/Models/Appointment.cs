using CarRentalSystem.Domain.Common;
using System;

namespace Domain.Models
{
    public class Appointment : Entity<int>
    {
        public string Diagnose { get; private set; }
        public Doctor Doctor { get; private set; }
        public DateTime Time { get; private set; }
        public Pet Pet { get; private set; }
        public bool MyProperty { get; private set; }
    }
}
