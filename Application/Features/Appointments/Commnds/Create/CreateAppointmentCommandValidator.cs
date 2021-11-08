using Application.Features.Appointments.Commands.Common;
using Application.Features.Appointments.Commnds.Create;
using Application.Features.Pets;
using FluentValidation;

namespace Application.Features.Appointments.Commnds.Common
{
    public class CreateAppointmentCommandValidator : AbstractValidator<CreateAppointmentCommand>
    {
        public CreateAppointmentCommandValidator(IPetsRepository petsRepository)
            => this.Include(new AppointmentValidator<CreateAppointmentCommand>(petsRepository));



    }
}
