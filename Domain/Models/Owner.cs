using CarRentalSystem.Domain.Common;
using System.Collections.Generic;

namespace Domain.Models
{
    public class Owner : Entity<int>
    {
        public string Name { get; private set; }
        public string MyProperty { get; private set; }
        public List<Pet> Pet { get; private set; }
    }
}
