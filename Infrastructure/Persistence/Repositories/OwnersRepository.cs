using Application.Features.Owners;
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
    internal class OwnersRepository : DataRepository<Owner>, IOwnersRepository
    {
        public OwnersRepository(PetClinicDbContext db) : base(db) { }

        public async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            var owner =
                this.Data
                .Owners
                .FirstOrDefault(o => o.Id == id);

            if(owner == null) { return false; }

            this.Data.Owners.Remove(owner);
            await this.Data.SaveChangesAsync();
            return true;
        }

        public async Task<Owner> FindById(int id, CancellationToken cancellationToken) =>
            await this.Data
            .Owners
            .FirstOrDefaultAsync(o=>o.Id == id);
        

        public async Task<Owner> FindByName(string name, CancellationToken cancellationToken) =>
        await this.Data
            .Owners
            .FirstOrDefaultAsync(o=>o.Name == name);
        }
}
