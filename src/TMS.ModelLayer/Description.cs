using System;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.Areas;
using TMS.ModelLayer.Tags;

namespace TMS.ModelLayer
{
    public struct Description : IActivityElement, ITagElement, IAreaElement
    {
        private readonly string _value;

        public string Value => _value;

        public Description(string value)
        {
            _value = value;
        }

        public IActivityVisitor Accept(IActivityVisitor visitor) => visitor.Visit(this);
        public ITagVisitor Accept(ITagVisitor visitor) => visitor.Visit(this);
        public IAreaVisitor Accept(IAreaVisitor visitor) => visitor.Visit(this);
    }
}
