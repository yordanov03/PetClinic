using Application.Features.Pets.Commands.Create;
using Microsoft.AspNetCore.Mvc;
using PetClinic.Web;
using System.Threading.Tasks;

namespace Web.Features
{
    public class PetsController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<CreatePetOutputModel>> Create(
            CreatePetCommand command) =>
            await this.Send(command);
    }
}
