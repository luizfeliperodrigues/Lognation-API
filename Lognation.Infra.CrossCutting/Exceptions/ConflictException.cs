using System;

namespace Lognation.Infra.CrossCutting.Exceptions
{
    [Serializable]
    public class ConflictException : Exception
    {
        public ConflictException() : base() { }

        public ConflictException(string message) : base(message) { }

        public ConflictException(string message, Exception innerException) : base(message, innerException) { }
    }
}
