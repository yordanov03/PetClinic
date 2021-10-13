﻿namespace CarRentalSystem.Application.Features.Identity.Commands.CreateUser
{
    using Common;
    using global::Application.Features.Identity;
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateUserCommand : UserInputModel, IRequest<Result>
    {
        public string Name { get; set; } = default!;

        public string PhoneNumber { get; set; } = default!;

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Result>
        {
            private readonly IIdentity identity;


            public CreateUserCommandHandler(IIdentity identity)
                => this.identity = identity;


            public async Task<Result> Handle(
                CreateUserCommand request,
                CancellationToken cancellationToken)
            {
                var result = await this.identity.Register(request);

                if (!result.Succeeded)
                {
                    return result;
                }

                return result;
            }
        }
    }
}