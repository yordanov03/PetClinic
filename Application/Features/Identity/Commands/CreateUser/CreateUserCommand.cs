using global::Application.Features.Identity;
using MediatR;
using PetClinic.Application.Common;
using System.Threading;
using System.Threading.Tasks;

namespace PetClinic.Application.Features.Identity.Commands.CreateUser
{
    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;


            public CreateUserCommandHandler(IIdentity identity) =>
                this.identity = identity;


            public async Task<Result> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken) =>
                await this.identity.Register(request);
        }
    }
}