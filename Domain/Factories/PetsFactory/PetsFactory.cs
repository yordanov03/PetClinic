using Domain.Exceptions;
using Domain.Models;
using System;

namespace Domain.Factories.PetsFactory
{
    internal class PetsFactory : IPetsFactory
    {
        private string petName;
        private int petAge;
        private Spicie petSpecie;
        private Owner petOwner;
        private string petPictureUrl;

        private bool spicieSet = false;
        public Pet Build()
        {
            if (!spicieSet)
            {
                throw new InvalidPetException("");
            }
            return new Pet(
                petName,
                petAge,
                petSpecie,
                petOwner,
                petPictureUrl);
        }
        public IPetsFactory WithName(string name)
        {
            this.petName = name;
            return this;
        }

        public IPetsFactory WithAge(int age)
        {
            this.petAge = age;
            return this;
        }

        public IPetsFactory WithOwner(Owner owner)
        {
            this.petOwner = owner;
            return this;
        }

        public IPetsFactory WithPictureUrl(string pictureUrl)
        {
            this.petPictureUrl = pictureUrl;
            return this;
        }

        public IPetsFactory WithSpicie(Spicie spicie)
        {
            this.petSpecie = spicie;
            return this;
        }
    }
}
