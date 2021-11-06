using Application.Features.Owners.Create;
using Microsoft.AspNetCore.Mvc;
using PetClinic.Web;
using System.Threading.Tasks;

namespace Web.Features
{
    public class OwnersController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<CreateOwnerOutputModel>> Create(
            CreateOwnerCommand command) =>
            await this.Send(command);
    }
}
