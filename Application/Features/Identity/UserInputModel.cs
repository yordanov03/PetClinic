namespace PetClinic.Application.Features.Identity.Commands
{
    public abstract class UserInputModel
    {
        public UserInputModel(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
        public string Email { get; set; } = default!;

        public string Password { get; set; } = default!;
    }
}
