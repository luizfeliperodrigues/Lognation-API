using System;

namespace Lognation.Infra.CrossCutting.Exceptions
{
    [Serializable]
    public class OutOfLimitException : Exception
    {
        public OutOfLimitException() : base() { }

        public OutOfLimitException(string message) : base(message) { }

        public OutOfLimitException(string message, Exception innerException) : base(message, innerException) { }
    }
}
