using System;

namespace TMS.Layer.Exceptions
{
    public class IdentifierNotSpecifiedException : Exception
    {
        public IdentifierNotSpecifiedException() : base("Must provide an identifier.")
        {
        }

        public IdentifierNotSpecifiedException(string message) : base(message)
        {
        }

        public IdentifierNotSpecifiedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
