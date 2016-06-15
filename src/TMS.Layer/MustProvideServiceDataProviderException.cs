using System;

namespace TMS.Layer
{
    public class MustProvideServiceDataProviderException : Exception
    {
        public MustProvideServiceDataProviderException()
        {
        }

        public MustProvideServiceDataProviderException(string message) : base(message)
        {
        }

        public MustProvideServiceDataProviderException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}