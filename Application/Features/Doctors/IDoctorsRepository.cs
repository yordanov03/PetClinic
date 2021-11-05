using Domain.Models;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Doctors
{
    public interface IDoctorsRepository
    {
        Task<Doctor> FindById(int id, CancellationToken cancellationToken = default);
        Task<Doctor> FindByName(string name, CancellationToken cancellationToken = default);
        Task<bool> Delete(int id, CancellationToken cancellationToken = default);
    }
}
