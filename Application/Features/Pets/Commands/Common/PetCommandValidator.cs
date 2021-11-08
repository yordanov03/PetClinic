using Application.Features.Owners;
using FluentValidation;
using System;
using static PetClinic.Domain.Models.ModelConstants.Common;

namespace Application.Features.Pets.Commands.Common
{
    public class PetCommandValidator<TCommand> : AbstractValidator<PetCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public PetCommandValidator(
            IPetsRepository petsRepository,
            IOwnersRepository ownersRepository)
        {
            this.RuleFor(p => p.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(p => p.Age)
                .LessThan(MaxAge)
                .NotEmpty();

            this.RuleFor(p => p.PictureUrl)
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("'{PropertyName}' must be a valid url.")
                .NotEmpty();

            this.RuleFor(p => p.OwnerId)
                .MustAsync(async (owner, token) => await ownersRepository
                .FindById(owner, token) != null)
                .WithMessage("Owner does not exist");

            this.RuleFor(p => p.SpecieId)
                .MustAsync(async (spicie, token) => await petsRepository.
                FindSpicieById(spicie, token) != null)
                .WithMessage("Spicie does not exist");
        }
    }
}
