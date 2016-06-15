using System;

namespace TMS.Database
{
    internal class DbContextMustBeProvidedException : Exception
    {
        public DbContextMustBeProvidedException() : base("The db context must be provided when initialising the database.")
        {
        }

        public DbContextMustBeProvidedException(string message) : base(message)
        {
        }

        public DbContextMustBeProvidedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}