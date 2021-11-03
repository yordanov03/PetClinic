using Domain.Models;
using FakeItEasy;
using System;

namespace Domain.Tests.Fakes
{
    public class SpicieFakes
    {
        public const string validSpicie = "Cat";

        public class SpicieDummyFactory : IDummyFactory
        {
            public Priority Priority => Priority.Default;

            public bool CanCreate(Type type) => type == typeof(Spicie);

            public object? Create(Type type) =>
                new Spicie(validSpicie);
        }
    }
}
