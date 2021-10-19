using Domain.Exceptions;
using PetClinic.Domain.Common;
using System.Collections.Generic;
using System.Linq;
using static PetClinic.Domain.Models.ModelConstants.Common;

namespace Domain.Models
{
    public class Owner : Entity<int>
    {
        private readonly List<Pet> pets;

        public Owner(
            string name,
            string phoneNumber)
        {
            Validate(name, phoneNumber);

            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.pets = new List<Pet>();
        }
        public string Name { get; private set; }
        public string PhoneNumber { get; private set; }
        public IReadOnlyCollection<Pet> Pets => this.pets.ToList().AsReadOnly();

        private void Validate(
            string name,
            string phoneNumber)
        {
            ValidateName(name);
            ValidatePhoneNumber(phoneNumber);
        }

        private void ValidateName(string name) =>
            Guard.ForStringLength<InvalidOwnerException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

        private void ValidatePhoneNumber(string phoneNumber) =>
            Guard.ForValidPhoneNumber<InvalidOwnerException>(
                phoneNumber,
                nameof(PhoneNumber));
    }
}
