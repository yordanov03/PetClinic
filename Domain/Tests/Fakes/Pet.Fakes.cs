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

            public bool CanCreate(Type type) => true;

            public object Create(Type type) =>
                new Pet(
                    "some pet",
                    3,
                    Spicie.cat,
                    new Owner(
                        "some owner",
                        "+122443545"),
                    "https://static.toiimg.com/thumb/msid-67586673,width-800,height-600,resizemode-75,imgsize-3918697,pt-32,y_pad-40/67586673.jpg",
                    new Doctor(
                        "some doctor"));
        }
    }
}
