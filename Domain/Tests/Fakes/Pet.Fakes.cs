using Domain.Models;
using FakeItEasy;
using System;

namespace Domain.Tests.Fakes
{
    public class PetFakes
    {
        public class PetDummyFactory : IDummyFactory
        {
            public Priority Priority => Priority.Default;

            public bool CanCreate(Type type) => type == typeof(Pet);

            public object? Create(Type type) =>
                new Pet(
                    "some pet",
                    3,
                    A.Dummy<Spicie>(),
                    A.Dummy<Owner>(),
                    "https://static.toiimg.com/thumb/msid-67586673,width-800,height-600,resizemode-75,imgsize-3918697,pt-32,y_pad-40/67586673.jpg");
        }
    }
}
