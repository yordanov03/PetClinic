using Application.Features.Owners.Commands.Create;
using Application.Features.Owners.Commands.Edit;
using Application.Features.Owners.Create;
using Microsoft.AspNetCore.Mvc;
using PetClinic.Application.Common;
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

        [HttpPut]
        public async Task<ActionResult<Result>> Edit(
            EditOwnerCommand command) =>
            await this.Send(command);
    }
}
