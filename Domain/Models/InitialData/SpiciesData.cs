using PetClinic.Domain.Common;
using System;
using System.Collections.Generic;

namespace Domain.Models.InitialData
{
    public class SpiciesData : IInitialData
    {
        public Type EntityType => typeof(Spicie);

        public IEnumerable<object> GetData() =>
            new List<Spicie>
            {
                new Spicie("Cat"),
                new Spicie("Dog"),
                new Spicie("Bird"),
                new Spicie("Fish"),
                new Spicie("Hamster"),
            };

    }
}
