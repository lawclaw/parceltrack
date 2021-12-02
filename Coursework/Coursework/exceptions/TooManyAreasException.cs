using System;
using System.Runtime.Serialization;

namespace Coursework.exceptions
{
    /// <summary>
    /// Exception when too many areas are entered
    /// </summary>
    public class TooManyAreasException : Exception
    {
        public TooManyAreasException()
        {
        }

        public TooManyAreasException(string message) : base(message)
        {
        }

        public TooManyAreasException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
