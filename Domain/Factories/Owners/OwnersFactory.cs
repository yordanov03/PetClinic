using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Factories.Owners
{
    public class OwnersFactory : IOwnersFactory
    {
        private string name = default!;
        private string phoneNumber = default;

        public Owner Build() =>
            new Owner(
                this.name,
                this.phoneNumber);
        

        public IOwnersFactory WithName(string name)
        {
            this.name = name;
            return this;
        }

        public IOwnersFactory WithPhoneNumber(string phoneNumber)
        {
            this.phoneNumber = phoneNumber;
            return this;
        }
    }
}
