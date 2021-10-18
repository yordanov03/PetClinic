using CarRentalSystem.Domain.Exceptions;

namespace Domain.Exceptions
{
    public class InvalidPetException: BaseDomainException
    {
        public InvalidPetException() { }

        public InvalidPetException(string message) => this.Message = message;



    }
}
