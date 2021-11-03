using Domain.Models;
using FakeItEasy;
using System;

namespace Domain.Tests.Fakes
{
    public class AppointmentFakes
    {
        public class AppointmentDummyFactory : IDummyFactory
        {
            public Priority Priority => Priority.Default;

            public bool CanCreate(Type type) => type == typeof(Appointment);

            public object? Create(Type type) =>
                new Appointment(

                    "some title",
                    "",
                    DateTime.Now,
                    A.Dummy<Pet>());
            
        }
    }
}
