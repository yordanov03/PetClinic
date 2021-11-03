using Domain.Exceptions;
using Domain.Models.InitialData;
using PetClinic.Domain.Common;
using System.Collections.Generic;
using System.Linq;
using static PetClinic.Domain.Models.ModelConstants.Common;

namespace Domain.Models
{
    public class Pet : Entity<int>, IAggregateRoot
    {
        private static readonly IEnumerable<Spicie> AllowedSpicies
            = new SpiciesData().GetData().Cast<Spicie>();

        public Pet(
            string name,
            int age,
            Spicie spicie,
            Owner owner,
            string pictureUrl)
        {
            Validate(name, age, pictureUrl, spicie);

            this.Name = name;
            this.Age = age;
            this.Spicie = spicie;
            this.Owner = owner;
            this.PictureUrl = pictureUrl;
        }

        internal Pet(
            string name,
            int age,
            string pictureUrl
            )
        {
            this.Name = name;
            this.Age = age;
            this.PictureUrl = pictureUrl;
            this.Spicie = default!;
            this.Owner = default!;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Spicie Spicie { get; private set; }
        public Owner Owner { get; private set; }
        public string PictureUrl { get; private set; }

        private void Validate(
            string name,
            int age,
            string picture,
            Spicie spicie)
        {
            ValidateName(name);
            ValidateAge(age);
            ValidatePictureUrl(picture);
            ValidateSpicie(spicie);
        }

        private void ValidateName(string name) =>
            Guard.ForStringLength<InvalidPetException>(
                name,
                MinNameLength,
                MaxNameLength,
                nameof(this.Name));

        private void ValidateAge(int age) =>
            Guard.ForAge<InvalidPetException>(
                age,
                Zero,
                MaxAge,
                nameof(this.Age));

        private void ValidatePictureUrl(string pictureUrl) =>
            Guard.ForValidUrl<InvalidPetException>(
                pictureUrl,
                nameof(this.PictureUrl));

        private void ValidateSpicie(Spicie spicie)
        {
            var spicieName = spicie?.Name;

            if(AllowedSpicies.Any(s=>s.Name == spicieName))
            {
                return;
            }

            var allowedSpicieNames = string.Join(", ", AllowedSpicies.Select(c => $"'{c.Name}'"));

            throw new InvalidPetException($"'{spicieName}' is not a valid category. Allowed values are: {allowedSpicieNames}.");
        }

        public Pet UpdateAge(int age)
        {
            ValidateAge(age);
            this.Age = age;
            return this;
        }

        public Pet UpdatePicture(string pictureUrl)
        {
            ValidatePictureUrl(pictureUrl);
            this.PictureUrl = pictureUrl;
            return this;
        }
    }
}

