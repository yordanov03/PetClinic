using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Queries.Find
{
    public class FindAppointmentByPetNameQuery : IRequest<AppointmentOutputModel>
    {
        public string? PetName { get; set; }

        public class FindByPetNameQueryHandler : IRequestHandler<FindAppointmentByPetNameQuery, AppointmentOutputModel>
        {
            
            public async Task<AppointmentOutputModel> Handle(FindAppointmentByPetNameQuery request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
