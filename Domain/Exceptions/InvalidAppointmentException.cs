using CarRentalSystem.Domain.Exceptions;

namespace Domain.Exceptions
{
    public class InvalidAppointmentException : BaseDomainException
    {
        public InvalidAppointmentException() { }
        public InvalidAppointmentException(string message) => this.Message = message;

    }
}
