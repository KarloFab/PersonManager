using System;
using System.Runtime.Serialization;

namespace Exceptions
{
    [Serializable]
    internal class InvalidOIBException : Exception
    {
        public InvalidOIBException() : base("OIB must be 11 digits!")
        {
        }

        public InvalidOIBException(string message) : base(message)
        {
        }
    }
}