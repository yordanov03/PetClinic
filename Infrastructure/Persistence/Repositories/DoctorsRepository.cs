using Application.Features.Doctors;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    internal class DoctorsRepository : DataRepository<Doctor>, IDoctorsRepository
    {
        public DoctorsRepository(PetClinicDbContext db) : base(db) { }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken = default)
        {
            var doctor =
                this.Data.
                Doctors.
                FirstOrDefault(d=>d.Id == id);

            if(doctor == null)
            {
                return false;
            }

            this.Data.Doctors.Remove(doctor);
            await this.Data.SaveChangesAsync();
            return true;

        }

        public async Task<Doctor> FindById(int id, CancellationToken cancellationToken = default) =>
            await this.Data
            .Doctors
            .FirstOrDefaultAsync(d => d.Id == id);


        public async Task<Doctor> FindByName(string name, CancellationToken cancellationToken = default) =>
            await this.Data
            .Doctors
            .FirstOrDefaultAsync(d => d.Name == name);
        
    }
}
