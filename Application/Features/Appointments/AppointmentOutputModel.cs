using System;

namespace Application.Features.Appointments
{
    public class AppointmentOutputModel
    {
        public int Id { get; private set; }
        public string Title { get; private set; } = default!;
        public string Diagnose { get; set; } = default!;
        public DateTime AppointmentTime { get; private set; } = default!;
        public string PetName { get; set; } = default!;
        public string DoctorName { get; private set; } = default!;
        public string OwnerName { get; private set; } = default!;
        public string OwnerPhoneNumber { get; private set; } = default!;
    }
}
