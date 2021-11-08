namespace Application.Features.Pets.Commands.Common
{
    public abstract class PetCommand<TCommand> : EntityCommand<int>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int OwnerId { get; set; }
        public string PictureUrl { get; set; }
        public int SpecieId { get; set; }
    }
}
