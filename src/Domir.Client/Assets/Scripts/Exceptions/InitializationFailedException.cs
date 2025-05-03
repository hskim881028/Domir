using System;

namespace Domir.Client.Exceptions
{
    public class InitializationFailedException : Exception
    {
        public InitializationFailedException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}