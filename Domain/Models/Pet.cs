﻿using Domain.Exceptions;
using PetClinic.Domain.Common;
using System.Collections.Generic;
using System.Linq;
using static PetClinic.Domain.Models.ModelConstants.Common;

namespace Domain.Models
{
    public class Pet : Entity<int>, IAggregateRoot
    {
        private readonly List<Appointment> medicalHistory;

        public Pet(
            string name,
            int age,
            Spicie spicie,
            Owner owner,
            string picture)
        {
            Validate(name, age, picture);

            this.Name = name;
            this.Age = age;
            this.Spicie = spicie;
            this.Owner = owner;
            this.Picutre = picture;
            this.medicalHistory = new List<Appointment>();
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public Spicie Spicie{ get; private set; }
        public Owner Owner { get; private set; }
        public string Picutre { get; private set; }
        public IReadOnlyCollection<Appointment> MedicalHistory => this.medicalHistory.ToList().AsReadOnly();

        private void Validate(
            string name,
            int age,
            string picture)
        {
            ValidateName(name);
            ValidateAge(age);
            ValidatePictureUrl(picture);
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

        private void ValidatePictureUrl(string picture) =>
            Guard.ForValidUrl<InvalidPetException>(
                picture,
                nameof(this.Picutre));

        public Pet UpdateAge(int age)
        {
            ValidateAge(age);
            this.Age = age;
            return this;
        }

        public Pet UpdatePicture(string picture)
        {
            ValidatePictureUrl(picture);
            this.Picutre = picture;
            return this;
        }
    }
}
