using Application.Features.Owners;
using Application.Features.Pets.Commands.Common;
using FluentValidation;

namespace Application.Features.Pets.Commands.Create
{
    public class CreatePetCommandValidator : AbstractValidator<CreatePetCommand>
    {
        public CreatePetCommandValidator(
            IPetsRepository petsRepository,
            IOwnersRepository ownersRepository) =>
            this.Include(new PetCommandValidator<CreatePetCommand>(petsRepository, ownersRepository));

    }
}
