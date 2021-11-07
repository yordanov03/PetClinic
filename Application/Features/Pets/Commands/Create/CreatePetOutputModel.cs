namespace Application.Features.Pets.Commands.Create
{
    public class CreatePetOutputModel
    {
        public CreatePetOutputModel(int id) =>
            this.Id = id;

        public int Id { get; }
    }
}
