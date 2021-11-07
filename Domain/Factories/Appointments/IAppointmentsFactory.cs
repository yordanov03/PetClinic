using Domain.Models;
using PetClinic.Domain.Factories;
using System;

namespace Domain.Factories
{
    public interface IAppointmentsFactory : IFactory<Appointment>
    {
        IAppointmentsFactory WithTitle(string title);
        IAppointmentsFactory WithDiagnose(string diagnose);
        IAppointmentsFactory WithAppointmentTime(DateTime appointmentTime);
        IAppointmentsFactory WithPet(Pet pet);
    }
}
