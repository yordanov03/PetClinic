using Application.Contracts;
using Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Owners
{
    public interface IOwnersRepository : IRepository<Owner>
    {
        Task<Owner> FindById(int id, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
        Task<Owner> FindByName(string name, CancellationToken cancellationToken);
    }
}
