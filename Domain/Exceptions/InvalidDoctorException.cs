using CarRentalSystem.Domain.Exceptions;

namespace Domain.Exceptions
{
    public class InvalidDoctorException : BaseDomainException
    {
        public InvalidDoctorException() { }
        public InvalidDoctorException(string message) => this.Message = message;

    }
}
