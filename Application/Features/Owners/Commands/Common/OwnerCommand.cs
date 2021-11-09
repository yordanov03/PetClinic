namespace Application.Features.Owners.Commands.Common
{
    public abstract class OwnerCommand<TCommand> : EntityCommand<int>
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
