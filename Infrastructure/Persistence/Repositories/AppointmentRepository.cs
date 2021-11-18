using Application.Features.Appointments;
using Application.Features.Appointments.Queries.GetByPetName;
using AutoMapper;
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
        private readonly IMapper mapper;

        public AppointmentRepository(PetClinicDbContext db, IMapper mapper) : base(db) =>
            this.mapper = mapper;

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


        public async Task<AppointmentsOutputModel> GetAllByDoctor(
            string doctorName,
            int skip = 0,
            int take = int.MaxValue,
            CancellationToken cancellationToken = default) =>
            (AppointmentsOutputModel)(await this.mapper
            .ProjectTo<AppointmentsOutputModel>
            (this.Data
            .Doctors
            .Where(a => a.Name == doctorName)
            .Select(a => a.Appointments))
            .ToListAsync(cancellationToken))
            .Skip(skip)
            .Take(take);

        public async Task<IEnumerable<Appointment>> GetAllByPetId(int petId, CancellationToken cancellationToken = default) =>
            (IEnumerable<Appointment>)await this.Data
            .Appointments
            .Where(a => a.Pet.Id == petId)
            .ToListAsync(cancellationToken);

        public async Task<AppointmentsOutputModel> GetAllByPetName(
            string petName, 
            int skip = 0,
            int take = int.MaxValue, 
            CancellationToken cancellationToken = default) =>
            (AppointmentsOutputModel)(await this.mapper
            .ProjectTo<AppointmentsOutputModel>
            (this.Data.Appointments.Where(p => p.Pet.Name == petName))
            .ToListAsync(cancellationToken))
            .Skip(skip)
            .Take(take);
        
    }
}
