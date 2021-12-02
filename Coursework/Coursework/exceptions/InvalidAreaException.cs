using System;

namespace Coursework.exceptions
{
    /// <summary>
    /// Exception when invalid area is entered
    /// </summary>
    public class InvalidAreaException : Exception
    {
        public InvalidAreaException()
        {
        }

        public InvalidAreaException(string message) : base(message)
        {
        }

        public InvalidAreaException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
