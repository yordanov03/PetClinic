using System;

namespace Application.Features.Appointments.Common
{
    public abstract class AppointmentCommand<TCommand> : EntityCommand<int>
    {
        public string Title { get; set; }
        public string Diagnose { get; set; }
        public DateTime AppointmentTime { get; set; }
        public int PetId { get; }

    }
}
