using Application.Features.Pets.Commands.Create;
using Application.Features.Pets.Commands.Delete;
using Application.Features.Pets.Commands.Edit;
using Microsoft.AspNetCore.Mvc;
using PetClinic.Application.Common;
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

        [HttpPost]
        public async Task<ActionResult<Result>> Edit(
            EditPetCommand command)
            => await this.Send(command);

        [HttpDelete]
        public async Task<ActionResult<Result>> Delete(
            DeletePetCommand command) =>
            await this.Send(command);
    }
}
