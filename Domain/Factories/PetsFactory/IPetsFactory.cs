using Domain.Models;
using PetClinic.Domain.Factories;

namespace Domain.Factories.PetsFactory
{
    public interface IPetsFactory : IFactory<Pet>
    {
        IPetsFactory WithName(string name);
        IPetsFactory WithAge(int age);
        IPetsFactory WithSpicie(Spicie spicie);
        IPetsFactory WithOwner(Owner owner);
        IPetsFactory WithPictureUrl(string pictureUrl);
    }
}
