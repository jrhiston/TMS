using System;

namespace TMS.ApplicationLayer.Exceptions
{
    public class ModelObjectNotFoundException : Exception
    {
        public ModelObjectNotFoundException() : base("Model object not found using the given identifier.")
        {
        }

        public ModelObjectNotFoundException(string message) : base(message)
        {
        }

        public ModelObjectNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
