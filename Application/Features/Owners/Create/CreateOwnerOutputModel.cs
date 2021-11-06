namespace Application.Features.Owners.Create
{
    public class CreateOwnerOutputModel
    {
        public CreateOwnerOutputModel(int id)
        => this.Id = id;

        public int Id { get; set; }
    }
}
