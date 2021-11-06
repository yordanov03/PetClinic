using Domain.Factories.Owners;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Owners.Create
{
    public class CreateOwnerCommand : IRequest<CreateOwnerOutputModel>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

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
