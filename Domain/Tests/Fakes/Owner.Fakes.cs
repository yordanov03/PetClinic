using Domain.Models;
using FakeItEasy;
using System;

namespace Domain.Tests.Fakes
{
    public class OwnerFakes
    {
        public class OwnerDummyFactory : IDummyFactory
        {
            public Priority Priority => Priority.Default;

            public bool CanCreate(Type type) => type == typeof(Owner);

            public object? Create(Type type) =>
                new Owner(
                    "some owner",
                    "+123446568");
        }
    }
}
