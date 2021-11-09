using Application.Features.Appointments;
using MediatR;
using PetClinic.Application.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Pets.Commands.Delete
{
    public class DeletePetCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeletePetCommandHandler : IRequestHandler<DeletePetCommand, Result>
        {
            private readonly IPetsRepository petsRepository;
            private readonly IAppointmentsRepository appointmentsRepository;

            public DeletePetCommandHandler(
                IPetsRepository petsRepository,
                IAppointmentsRepository appointmentsRepository)
            {
                this.petsRepository = petsRepository;
                this.appointmentsRepository = appointmentsRepository;
            }
            public async Task<Result> Handle(DeletePetCommand request, CancellationToken cancellationToken)
            {
                var appoinemtns = await this.appointmentsRepository.GetAllByPetId(request.Id, cancellationToken);

                foreach (var appointment in appoinemtns)
                {
                    await this.appointmentsRepository
                        .DeleteAppointment(appointment.Id, cancellationToken);
                }

                return await this.petsRepository
                    .Delete(request.Id, cancellationToken);
            }
        }
    }
}
