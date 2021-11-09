using Application.Features.Owners.Commands.Common;
using MediatR;
using PetClinic.Application.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Owners.Commands.Edit
{
    public class EditOwnerCommand : OwnerCommand<EditOwnerCommand>, IRequest<Result>
    {
        public class EditOwnerCommandHandler : IRequestHandler<EditOwnerCommand, Result>
        {
            private readonly IOwnersRepository ownersRepository;

            public EditOwnerCommandHandler(IOwnersRepository ownersRepository)
            => this.ownersRepository = ownersRepository;

            public async Task<Result> Handle(EditOwnerCommand request, CancellationToken cancellationToken)
            {
                var owner = await this.ownersRepository
                    .FindById(request.Id, cancellationToken);

                owner
                    .UpdatePhoneNumber(request.PhoneNumber);

                await this.ownersRepository.Save(owner);
                return Result.Success;
            }
        }
    }
}
