using Application.Features.Owners.Commands.Common;
using Application.Features.Owners.Create;
using Domain.Factories.Owners;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Owners.Commands.Create
{
    public class CreateOwnerCommand : OwnerCommand<CreateOwnerCommand>, IRequest<CreateOwnerOutputModel>
    {
        public class CreateOwnerCommandHandler : IRequestHandler<CreateOwnerCommand, CreateOwnerOutputModel>
        {
            private readonly IOwnersRepository ownersRepository;
            private readonly IOwnersFactory ownersFactory;

            public CreateOwnerCommandHandler(
                IOwnersRepository ownersRepository,
                IOwnersFactory ownersFactory)
            {
                this.ownersRepository = ownersRepository;
                this.ownersFactory = ownersFactory;

            }
            public async Task<CreateOwnerOutputModel> Handle(CreateOwnerCommand request, CancellationToken cancellationToken)
            {
                var owner = this.ownersFactory
                    .WithName(request.Name)
                    .WithPhoneNumber(request.PhoneNumber)
                    .Build();

                await this.ownersRepository.Save(owner, cancellationToken);
                return new CreateOwnerOutputModel(owner.Id);
            }
        }
    }
}
