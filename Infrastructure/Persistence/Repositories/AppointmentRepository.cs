using Application.Features.Appointments;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    internal class AppointmentRepository : DataRepository<Appointment>, IAppointmentRepository
    {
        public AppointmentRepository(PetClinicDbContext db) : base(db) { }

        public Task<bool> DeleteAppointment(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Appointment> FindById(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Appointment>> GetAllByDoctor(string doctorName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Appointment>> GetAllByOwner(string ownerName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Appointment>> GetAllByPet(string petName, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
