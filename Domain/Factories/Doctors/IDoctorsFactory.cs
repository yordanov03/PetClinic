using Domain.Models;
using PetClinic.Domain.Factories;

namespace Domain.Factories.Doctors
{
    public interface IDoctorsFactory : IFactory<Doctor>
    {
        IDoctorsFactory WithName(string name);
    }
}
