using System;

namespace TMS.Layer.Exceptions
{
    public class MustProvideInitialiserDataException : Exception
    {
        public MustProvideInitialiserDataException() : base("Must provide initialiser data.")
        {
        }

        public MustProvideInitialiserDataException(string message) : base(message)
        {
        }

        public MustProvideInitialiserDataException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
