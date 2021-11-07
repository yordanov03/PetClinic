using Application.Contracts;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Pets
{
    public interface IPetsRepository : IRepository<Pet>
    {
        Task<Pet> FindById(int id, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
        Task<Pet> FindByName(string name, CancellationToken cancellationToken);
        Task<Spicie> FindSpicieById(int id, CancellationToken cancellationToken);
    }
}
