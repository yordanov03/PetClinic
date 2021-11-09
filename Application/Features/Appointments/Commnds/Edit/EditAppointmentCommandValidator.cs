using Application.Features.Appointments.Commands.Common;
using Application.Features.Pets;
using FluentValidation;

namespace Application.Features.Appointments.Commnds.Edit
{
    public class EditAppointmentCommandValidator : AbstractValidator<EditAppointmentCommand>
    {
        public EditAppointmentCommandValidator(IPetsRepository petsRepository) =>
        this.Include(new AppointmentValidator<EditAppointmentCommand>(petsRepository));
    }
}
