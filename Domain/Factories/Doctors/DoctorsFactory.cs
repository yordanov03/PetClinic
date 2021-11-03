using Domain.Models;

namespace Domain.Factories.Doctors
{
    internal class DoctorsFactory : IDoctorsFactory
    {
        private string doctorName;

        public Doctor Build() =>
            this.WithName(doctorName)
            .Build();

        public IDoctorsFactory WithName(string name)
        {
            this.doctorName = name;
            return this;
        }
    }
}
