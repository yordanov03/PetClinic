using Application.Features.Appointments.Common;
using Application.Features.Pets;
using Domain.Factories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Commnds.Create
{
    public class CreateAppointmentCommand : AppointmentCommand<CreateAppointmentCommand>, IRequest<CreateAppointmentOutputModel>
    {
        public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, CreateAppointmentOutputModel>
        {
            private readonly IAppointmentsRepository appointmentRepository;
            private readonly IPetsRepository petRepository;
            private readonly IAppointmentsFactory appointmentFactory;

            public CreateAppointmentCommandHandler(
                IAppointmentsRepository appointmentRepository,
                IPetsRepository petRepository,
                IAppointmentsFactory appointmentFactory)
            {
                this.appointmentRepository = appointmentRepository;
                this.petRepository = petRepository;
                this.appointmentFactory = appointmentFactory;
            }
            public async Task<CreateAppointmentOutputModel> Handle(CreateAppointmentCommand request, CancellationToken cancellationToken)
            {
                var pet = await this.petRepository.FindById(request.PetId, cancellationToken);

                var appointment = this.appointmentFactory
                    .WithTitle(request.Title)
                    .WithDiagnose(request.Diagnose)
                    .WithAppointmentTime(request.AppointmentTime)
                    .WithPet(pet)
                    .Build();

                await this.appointmentRepository.Save(appointment, cancellationToken);

                return new CreateAppointmentOutputModel(appointment.Id);
            }
        }
    }
}
