using System;

namespace TMS.Layer.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct)]
    public class LinkedToAttribute : Attribute
    {
        public Type[] LinkedTypes { get; }

        public LinkedToAttribute(params Type[] linkedTypes)
        {
            LinkedTypes = linkedTypes;
        }
    }
}
