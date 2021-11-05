using Domain.Exceptions;
using PetClinic.Domain.Common;

namespace Domain.Models
{
     public class Spicie : Entity<int>
    {
        public Spicie(string name)
        {
            this.Validate(name);
            this.Name = name;
        }

        internal Spicie()
        {
            this.Name = default!;
        }


        public string Name { get; }

        private void Validate(string name)
        {
            Guard.AgainstEmptyString<InvalidPetException>(
                name,
                nameof(Name));
        }
    }
}
