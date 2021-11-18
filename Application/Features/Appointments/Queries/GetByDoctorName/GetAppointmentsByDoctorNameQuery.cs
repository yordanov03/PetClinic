using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Queries.GetByDoctorName
{
    public class GetAppointmentsByDoctorNameQuery : IRequest<AppointmentsOutputModel>
    {
        private const int appointmentsPerPage = 10;
        public string DoctorName { get; set; }
        public int Page { get; set; } = 1;

        public class GetAppointmentsByDoctorNameHandler : IRequestHandler<GetAppointmentsByDoctorNameQuery, AppointmentsOutputModel>
        {
            private readonly IAppointmentsRepository appointmentsRepository;

            public GetAppointmentsByDoctorNameHandler(IAppointmentsRepository appointmentsRepository) =>
                this.appointmentsRepository = appointmentsRepository;
            
            public async Task<AppointmentsOutputModel> Handle(GetAppointmentsByDoctorNameQuery request, CancellationToken cancellationToken)
            => await this.appointmentsRepository
                .GetAllByPetName(request.DoctorName,
                request.Page,
                appointmentsPerPage,
                cancellationToken);
        }
    }
}
