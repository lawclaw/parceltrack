using System;

namespace Coursework.exceptions
{
    /// <summary>
    /// Exception when parcel creation fails
    /// </summary>
    public class FailedToAddParcelException : Exception
    {
        public FailedToAddParcelException()
        {
        }

        public FailedToAddParcelException(string message) : base(message)
        {
        }

        public FailedToAddParcelException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
