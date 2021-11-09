using Application.Features.Pets.Commands.Common;
using MediatR;
using PetClinic.Application.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Pets.Commands.Edit
{
    public class EditPetCommand : PetCommand<EditPetCommand>, IRequest<Result>
    {
        public class EditPetCommandHandler : IRequestHandler<EditPetCommand, Result>
        {
            private readonly IPetsRepository petsRepository;

            public EditPetCommandHandler(IPetsRepository petsRepository)
                => this.petsRepository = petsRepository;

            public async Task<Result> Handle(EditPetCommand request, CancellationToken cancellationToken)
            {
                var pet = await this.petsRepository
                    .FindById(request.Id, cancellationToken);

                pet
                    .UpdateAge(request.Age)
                    .UpdatePicture(request.PictureUrl);

                await this.petsRepository.Save(pet, cancellationToken);
                return Result.Success;
            }
        }
    }
}
