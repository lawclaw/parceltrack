using System;

namespace Coursework.exceptions
{
    /// <summary>
    /// Exception when courier creation fails
    /// </summary>
    public class FailedToAddCourierException : Exception
    {
        public FailedToAddCourierException()
        {
        }

        public FailedToAddCourierException(string message) : base(message)
        {
        }

        public FailedToAddCourierException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
