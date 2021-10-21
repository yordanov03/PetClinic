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

            public bool CanCreate(Type type) => true;

            public object Create(Type type) =>
                new Appointment(
                    "some diagnose",
                    DateTime.Now,
                    new Pet(
                        "a pet",
                        3,
                        Spicie.cat,
                        new Owner(
                            "some owner",
                            "+1234568"),
                        "https://toppng.com/uploads/preview/cat-11525956124t37pf0dhfz.png",
                        new Doctor(
                            "some doctor")));
            
        }
    }
}
