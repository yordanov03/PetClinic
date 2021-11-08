using Application.Features.Appointments.Common;
using Application.Features.Pets;
using FluentValidation;
using System;
using static PetClinic.Domain.Models.ModelConstants.Common;

namespace Application.Features.Appointments.Commands.Common
{
    public class AppointmentValidator<TCommand> : AbstractValidator<AppointmentCommand<TCommand>>
        where TCommand : EntityCommand<int>
    {
        public AppointmentValidator(IPetsRepository petsRepository)
        {
            this.RuleFor(a => a.Title)
                .MinimumLength(MinStringLength)
                .MaximumLength(MaxStringLength)
                .NotEmpty();

            this.RuleFor(a => a.AppointmentTime)
                .GreaterThan(DateTime.Now)
                .NotEmpty();

            this.RuleFor(a => a.PetId)
                .MustAsync(async (petId, token) => await petsRepository
                .FindById(petId, token) != null)
                .WithMessage("Pet does not exist.");
        }
    }
}
