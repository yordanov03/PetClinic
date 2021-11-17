using Application.Features.Appointments;
using Application.Features.Pets;
using MediatR;
using PetClinic.Application.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Owners.Commands.Delete
{
    public class DeleteOwnerCommand : EntityCommand<int>, IRequest<Result>
    {
        public class DeleteOwnerCommandHandler : IRequestHandler<DeleteOwnerCommand, Result>
        {
            private readonly IOwnersRepository ownersRepository;
            private readonly IAppointmentsRepository appointmentsRepository;
            private readonly IPetsRepository petsRepository;

            public DeleteOwnerCommandHandler(
                IOwnersRepository ownersRepository,
                IAppointmentsRepository appointmentsRepository,
                IPetsRepository petsRepository)
            {
                this.ownersRepository = ownersRepository;
                this.appointmentsRepository = appointmentsRepository;
                this.petsRepository = petsRepository;
            }

            public async Task<Result> Handle(DeleteOwnerCommand request, CancellationToken cancellationToken)
            {
                var owner = await this.ownersRepository
                    .FindById(request.Id, cancellationToken);

                var petIds = owner.Pets.Select(p => p.Id).ToList();

                foreach (var petId in petIds)
                {
                    var appointments = await this.appointmentsRepository
                        .GetAllByPetId(petId, cancellationToken);

                    foreach (var appointment in appointments)
                    {
                        await this.appointmentsRepository
                            .DeleteAppointment(appointment.Id, cancellationToken);
                    }

                    await this.petsRepository.Delete(petId, cancellationToken);
                }

                return await this.ownersRepository.Delete(request.Id, cancellationToken);
            }
        }
    }
}
