using MediatR;
using PetClinic.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Commnds.Delete
{
    public class DeleteAppointmentCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteAppointmentCommandHandler : IRequestHandler<DeleteAppointmentCommand, Result>
        {
            private readonly IAppointmentsRepository appointmentsRepository;

            public DeleteAppointmentCommandHandler(IAppointmentsRepository appointmentsRepository)
                => this.appointmentsRepository = appointmentsRepository;


            public async Task<Result> Handle(DeleteAppointmentCommand request, CancellationToken cancellationToken)
            {
                return await this.appointmentsRepository
                    .DeleteAppointment(request.Id, cancellationToken);
            }
        }
    }
}
