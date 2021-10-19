namespace PetClinic.Domain.Common
{
    using System;
    using System.Text.RegularExpressions;
    using Exceptions;
    using Models;
    using static PetClinic.Domain.Models.ModelConstants;

    public static class Guard
    {
        public static void AgainstEmptyString<TException>(string value, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (!string.IsNullOrEmpty(value))
            {
                return;
            }

            ThrowException<TException>($"{name} cannot be null ot empty.");
        }

        public static void ForStringLength<TException>(string value, int minLength, int maxLength, string name = "Value")
            where TException : BaseDomainException, new()
        {
            AgainstEmptyString<TException>(value, name);

            if (minLength <= value.Length && value.Length <= maxLength)
            {
                return;
            }

            ThrowException<TException>($"{name} must have between {minLength} and {maxLength} symbols.");
        }

        public static void ForAge<TException>(int value, int minLength, int maxLength, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (value >= 0)
            {
                return;
            }

            ThrowException<TException>($"Age must be between {minLength} and {maxLength}.");
        }

        public static void AgainstOutOfRange<TException>(int number, int min, int max, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (min <= number && number <= max)
            {
                return;
            }

            ThrowException<TException>($"{name} must be between {min} and {max}.");
        }

        public static void AgainstOutOfRange<TException>(decimal number, decimal min, decimal max, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (min <= number && number <= max)
            {
                return;
            }

            ThrowException<TException>($"{name} must be between {min} and {max}.");
        }

        public static void ForValidTime<TException>(DateTime time, string name = "Value")
            where TException : BaseDomainException, new()
        {
            var currentTime = DateTime.Now;

            if (time > currentTime.AddHours(Common.MaxTimeDifferenceInHours))
            {
                return;
            }

            ThrowException<TException>($"Time cannot be in the past.");
        }

        public static void ForValidUrl<TException>(string url, string name = "Value")
            where TException : BaseDomainException, new()
        {
            bool validPicUrl = Regex.IsMatch(url, PicUrl.MatchingUrl);

            if (url.Length <= ModelConstants.Common.MaxUrlLength && 
                Uri.IsWellFormedUriString(url, UriKind.Absolute) && 
                validPicUrl)
            {
                return;
            }

            ThrowException<TException>($"{name} must be a valid URL.");
        }

        public static void ForValidPhoneNumber<TException>(string phoneNumber, string name = "Value")
           where TException : BaseDomainException, new()
        {
            bool validPhoneNumber = Regex.IsMatch(phoneNumber, PhoneNumber.PhoneNumberRegularExpression);

            if (phoneNumber.Length >= ModelConstants.PhoneNumber.MinPhoneNumberLength &&
                phoneNumber.Length<= ModelConstants.PhoneNumber.MaxPhoneNumberLength &&
                validPhoneNumber)
            {
                return;
            }

            ThrowException<TException>($"{name} must be a valid URL.");
        }


        public static void Against<TException>(object actualValue, object unexpectedValue, string name = "Value")
            where TException : BaseDomainException, new()
        {
            if (!actualValue.Equals(unexpectedValue))
            {
                return;
            }

            ThrowException<TException>($"{name} must not be {unexpectedValue}.");
        }

        private static void ThrowException<TException>(string message)
            where TException : BaseDomainException, new()
        {
            var exception = new TException
            {
                Message = message
            };

            throw exception;
        }
    }
}
