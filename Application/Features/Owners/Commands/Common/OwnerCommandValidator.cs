using FluentValidation;
using static PetClinic.Domain.Models.ModelConstants.Common;
using static PetClinic.Domain.Models.ModelConstants.PhoneNumber;

namespace Application.Features.Owners.Commands.Common
{
    public class OwnerCommandValidator<TCommand> : AbstractValidator<OwnerCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public OwnerCommandValidator()
        {
            this.RuleFor(o => o.Name)
                .MinimumLength(MinNameLength)
                .MaximumLength(MaxNameLength)
                .NotEmpty();

            this.RuleFor(o => o.PhoneNumber)
                .MinimumLength(MinPhoneNumberLength)
                .MaximumLength(MaxPhoneNumberLength)
                .NotEmpty();
        }
    }
}
