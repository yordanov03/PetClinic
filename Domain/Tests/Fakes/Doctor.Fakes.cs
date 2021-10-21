using Domain.Models;
using FakeItEasy;
using System;

namespace Domain.Tests.Fakes
{
    public class DoctorFakes
    {
        public class DoctorDummyFactory : IDummyFactory
        {
            public Priority Priority => Priority.Default;

            public bool CanCreate(Type type) => true;

            public object Create(Type type) =>
                new Doctor("some doctor");
        }
    }
}
