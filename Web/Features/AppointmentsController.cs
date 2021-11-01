using Application.Contracts;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using PetClinic.Web;
using System.Collections.Generic;

namespace Web.Features
{

    public class AppointmentsController : ApiController
    {
        private readonly IRepository<Appointment> appointments;

        public AppointmentsController(IRepository<Appointment> appointments)
            => this.appointments = appointments;


        [HttpGet]
        public IEnumerable<Appointment> GetAllAppointments() =>
            (IEnumerable<Appointment>)this.appointments;
    }
}
