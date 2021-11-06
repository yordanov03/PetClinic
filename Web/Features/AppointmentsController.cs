using Application.Features.Appointments.Commnds.Create;
using Microsoft.AspNetCore.Mvc;
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
    }
}
