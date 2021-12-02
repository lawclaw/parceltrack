using System;

namespace Coursework.exceptions
{
    /// <summary>
    /// Exception when courier has reached full capacity
    /// </summary>
    public class FullCourierException : Exception
    {
        public FullCourierException()
        {
        }

        public FullCourierException(string message) : base(message)
        {
        }

        public FullCourierException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}
