using Application.Features.Pets;
using Domain.Factories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Appointments.Commnds.Create
{
    public class CreateAppointmentCommand : IRequest<CreateAppointmentOutputModel>
    {
        public string Title { get; }
        public string Diagnose { get; }
        public DateTime AppointmentTime { get; }
        public int PetId { get; }


        public class CreateAppointmentCommandHandler : IRequestHandler<CreateAppointmentCommand, CreateAppointmentOutputModel>
        {
            private readonly IAppointmentRepository appointmentRepository;
            private readonly IPetsRepository petRepository;
            private readonly IAppointmentFactory appointmentFactory;

            public CreateAppointmentCommandHandler(
                IAppointmentRepository appointmentRepository,
                IPetsRepository petRepository,
                IAppointmentFactory appointmentFactory)
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
