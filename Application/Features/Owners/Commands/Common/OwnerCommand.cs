using PetClinic.Domain.Common;

namespace Application.Features.Owners.Commands.Common
{
    public class OwnerCommand<TCommand> : Entity<int>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
