using System;

namespace Coursework.exceptions
{
    /// <summary>
    /// Exception when invalid delivery id is entered
    /// </summary>
    public class InvalidDeliveryIdException : Exception
    {
        public InvalidDeliveryIdException()
        {
        }

        public InvalidDeliveryIdException(string message) : base(message)
        {
        }

        public InvalidDeliveryIdException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
