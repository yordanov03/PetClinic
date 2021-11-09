using Application.Features.Appointments.Common;
using Application.Features.Pets;
using MediatR;
using PetClinic.Application.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Commnds.Edit
{
    public class EditAppointmentCommand : AppointmentCommand<EditAppointmentCommand>, IRequest<Result>
    {
        public class EditAppointmentCommandHandler : IRequestHandler<EditAppointmentCommand, Result>
        {
            private readonly IAppointmentsRepository appointmentRepository;
            private readonly IPetsRepository petRepository;

            public EditAppointmentCommandHandler(IAppointmentsRepository appointmentRepository) =>
                this.appointmentRepository = appointmentRepository;

            public async Task<Result> Handle(EditAppointmentCommand request, CancellationToken cancellationToken)
            {
                var appointment = await this.appointmentRepository
                    .FindById(request.Id, cancellationToken);

                appointment
                    .UpdateAppointmentTime(request.AppointmentTime)
                    .UpdateDiagnose(request.Diagnose);

                await this.appointmentRepository.Save(appointment, cancellationToken);

                return Result.Success;
            }
        }
    }
}
