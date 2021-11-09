using Application.Features.Owners.Commands.Common;
using FluentValidation;

namespace Application.Features.Owners.Commands.Edit
{
    public class EditOwnerCommandValidator : AbstractValidator<EditOwnerCommand>
    {
        public EditOwnerCommandValidator(IOwnersRepository ownersRepository)
            => this.Include(new OwnerCommandValidator<EditOwnerCommand>(ownersRepository));

    }
}
