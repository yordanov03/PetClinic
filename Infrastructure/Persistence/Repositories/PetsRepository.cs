using Application.Features.Pets;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    internal class PetsRepository : DataRepository<Pet>, IPetsRepository
    {
        public PetsRepository(PetClinicDbContext db) : base(db) { }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var pet =
                this.Data
                .Pets
                .FirstOrDefault(p => p.Id == id);

            if(pet == null) { return false; }

            this.Data
                .Pets
                .Remove(pet);

            await this.Data.SaveChangesAsync();
            return true;
        }

        public async Task<Pet> FindById(int id, CancellationToken cancellationToken = default) =>
            await this.Data
            .Pets
            .FirstOrDefaultAsync(p => p.Id == id);
        

        public async Task<Pet> FindByName(string name, CancellationToken cancellationToken) =>
        await this.Data
            .Pets
            .FirstOrDefaultAsync(p => p.Name == name);

        public async Task<Spicie> FindSpicieById(int id, CancellationToken cancellationToken) =>
        await this.Data
            .Spicies
            .FirstOrDefaultAsync(s => s.Id == id);
    }
}
