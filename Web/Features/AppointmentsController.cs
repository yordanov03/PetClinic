using Application.Features.Appointments;
using Application.Features.Appointments.Commnds.Create;
using Application.Features.Appointments.Commnds.Delete;
using Application.Features.Appointments.Commnds.Edit;
using Application.Features.Appointments.Queries.GetByDoctorName;
using Application.Features.Appointments.Queries.GetByPetName;
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

        [HttpDelete]
        public async Task<ActionResult<Result>> Delete(
            DeleteAppointmentCommand command) =>
            await this.Send(command);

        [HttpGet]
        public async Task<ActionResult<AppointmentsOutputModel>> GetAppointmentsByPetName(
            GetAppointmentsByPetNameQuery query) =>
            await this.Send(query);

        [HttpGet]
        public async Task<ActionResult<AppointmentsOutputModel>> GetAppointmentsByDoctor(
            GetAppointmentsByDoctorNameQuery query) =>
            await this.Send(query);
    }
}
