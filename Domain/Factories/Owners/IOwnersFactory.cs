using Domain.Models;
using PetClinic.Domain.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.Owners
{
    public interface IOwnersFactory : IFactory<Owner>
    {
        IOwnersFactory WithName(string name);
        IOwnersFactory WithPhoneNumber(string phoneNumber);
    }
}
