using PetClinic.Domain.Exceptions;

namespace Domain.Exceptions
{
    public class InvalidOwnerException : BaseDomainException
    {
        public InvalidOwnerException() { }

        public InvalidOwnerException(string message) => this.Message = message;

    }
}
