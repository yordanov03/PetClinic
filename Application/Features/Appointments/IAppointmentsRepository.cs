﻿using Application.Contracts;
using Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Appointments
{
    public interface IAppointmentsRepository : IRepository<Appointment>
    {
        Task<Appointment> FindById(int id, CancellationToken cancellationToken = default);
        Task<bool> DeleteAppointment(int id, CancellationToken cancellationToken = default);
        Task<IEnumerable<Appointment>> GetAllByDoctor(string doctorName, CancellationToken cancellationToken = default);
        Task<IEnumerable<Appointment>> GetAllByPetId(int petId, CancellationToken cancellationToken = default);
    }
}

