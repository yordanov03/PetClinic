using Application.Features.Appointments.Commnds.Create;
using Application.Features.Appointments.Commnds.Edit;
using Microsoft.AspNetCore.Mvc;
using PetClinic.Application.Common;
using PetClinic.Web;
using System.Threading.Tasks;

namespace Web.Features
{

    public class AppointmentsController : ApiController
    {

        [HttpPost]
        public async Task<ActionResult<CreateAppointmentOutputModel>> Create(
            CreateAppointmentCommand command) =>
            await this.Send(command);

        [HttpPut]
        public async Task<ActionResult<Result>> Edit(
            EditAppointmentCommand command) =>
            await this.Send(command);
    }
}
