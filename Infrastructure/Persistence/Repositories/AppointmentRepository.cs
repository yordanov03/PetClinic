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
    internal class AppointmentRepository : DataRepository<Appointment>, IAppointmentsRepository
    {
        public AppointmentRepository(PetClinicDbContext db) : base(db) { }

        public async Task<bool> DeleteAppointment(int id, CancellationToken cancellationToken = default)
        {
            var appointment = await this.Data.Appointments.FirstOrDefaultAsync(a => a.Id == id);

            if(appointment == null)
            {
                return false;
            }

            this.Data.Appointments.Remove(appointment);
            await this.Data.SaveChangesAsync();
            return true;

        }

        public async Task<Appointment> FindById(int id, CancellationToken cancellationToken = default) =>
            await this
            .Data
            .Appointments
            .FirstOrDefaultAsync(a => a.Id == id);


        public async Task<IEnumerable<Appointment>> GetAllByDoctor(string doctorName, CancellationToken cancellationToken = default) =>
            (IEnumerable<Appointment>)await this.Data
            .Doctors
            .Where(a => a.Name == doctorName)
            .Select(a => a.Appointments)
            .ToListAsync(cancellationToken);

        public async Task<IEnumerable<Appointment>> GetAllByPetId(int petId, CancellationToken cancellationToken = default) =>
            (IEnumerable<Appointment>)await this.Data
            .Appointments
            .Where(a => a.Pet.Id == petId)
            .ToListAsync(cancellationToken);
        
    }
}
