using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Queries.GetByPetName
{
    public class GetAppointmentsByPetNameQuery : IRequest<AppointmentsOutputModel>
    {
        private const int appointmentsPerPage = 10;
        public string? PetName { get; set; }
        public int Page { get; set; } = 1;

        public class FindByPetNameQueryHandler : IRequestHandler<GetAppointmentsByPetNameQuery, AppointmentsOutputModel>
        {
            private readonly IAppointmentsRepository appointmentsRepository;

            public FindByPetNameQueryHandler(IAppointmentsRepository appointmentsRepository)
            => this.appointmentsRepository = appointmentsRepository;

            public async Task<AppointmentsOutputModel> Handle(GetAppointmentsByPetNameQuery request, CancellationToken cancellationToken)
            => await this.appointmentsRepository
                .GetAllByPetName(request.PetName,
                request.Page,
                appointmentsPerPage,
                cancellationToken);
        }
    }
}
