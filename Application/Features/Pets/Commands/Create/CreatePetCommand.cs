using Application.Features.Owners;
using Application.Features.Pets.Commands.Common;
using Domain.Factories.PetsFactory;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Pets.Commands.Create
{
    public class CreatePetCommand : PetCommand<CreatePetCommand>, IRequest<CreatePetOutputModel>
    {
        public class CreatePetCommandHandler : IRequestHandler<CreatePetCommand, CreatePetOutputModel>
        {

            private readonly IPetsRepository petsRepository;
            private readonly IOwnersRepository ownersRepository;
            private readonly IPetsFactory petsFactory;

            public CreatePetCommandHandler(
                IPetsRepository petsRepository,
                IOwnersRepository ownersRepository,
                IPetsFactory petsFactory)
            {
                this.petsRepository = petsRepository;
                this.ownersRepository = ownersRepository;
                this.petsFactory = petsFactory;
            }

            public async Task<CreatePetOutputModel> Handle(CreatePetCommand request, CancellationToken cancellationToken)
            {
                var owner = await this.ownersRepository
                    .FindById(request.OwnerId, cancellationToken);

                var spicie = await this.petsRepository
                    .FindSpicieById(request.SpecieId, cancellationToken);

                var pet = this.petsFactory
                    .WithName(request.Name)
                    .WithAge(request.Age)
                    .WithPictureUrl(request.PictureUrl)
                    .WithOwner(owner)
                    .WithSpicie(spicie)
                    .Build();

                await this.petsRepository.Save(pet, cancellationToken);
                return new CreatePetOutputModel(pet.Id);

            }
        }
    }
}
