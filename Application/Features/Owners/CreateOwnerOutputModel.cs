namespace Application.Features.Owners
{
    public class CreateOwnerOutputModel
    {
        public CreateOwnerOutputModel(int id) =>
            this.Id = id;

        public int Id { get; set; }
    }
}
