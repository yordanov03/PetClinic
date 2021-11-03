using Domain.Models;
using PetClinic.Domain.Factories;
using System;

namespace Domain.Factories
{
    public interface IAppointmentFactory : IFactory<Appointment>
    {
        IAppointmentFactory WithTitle(string title);
        IAppointmentFactory WithDiagnose(string diagnose);
        IAppointmentFactory WithAppointmentTime(DateTime appointmentTime);
        IAppointmentFactory WithPet(Pet pet);
    }
}
