using Application.Contracts;
using PetClinic.Domain.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    internal abstract class DataRepository<TEntity>
        : IRepository<TEntity>
        where TEntity : class, IAggregateRoot
    {
        protected DataRepository(PetClinicDbContext db) => this.Data = db;

        protected PetClinicDbContext Data { get; }

        protected IQueryable<TEntity> All() => this.Data.Set<TEntity>();

        public async Task Save(
            TEntity entity,
            CancellationToken cancellationToken = default)
        {
            this.Data.Update(entity);

            await this.Data.SaveChangesAsync(cancellationToken);
        }
    }
}
