using System.Collections.Generic;

namespace Application.Features.Appointments
{
    public class AppointmentsOutputModel
    {
        public AppointmentsOutputModel(
            IEnumerable<AppointmentOutputModel> appointments,
            int page,
            int totalPages)
        {
            this.Appointments = appointments;
            this.Page = page;
            this.TotalPages = totalPages;
        }
        public IEnumerable<AppointmentOutputModel> Appointments { get; }
        public int Page { get; }

        public int TotalPages { get; }
    }
}
