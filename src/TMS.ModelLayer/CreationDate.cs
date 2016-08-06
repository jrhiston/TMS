using System;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.Areas;
using TMS.ModelLayer.Tags;

namespace TMS.ModelLayer
{
    public struct CreationDate : IActivityElement, ITagElement, IAreaElement
    {
        public DateTime Value { get; }

        public CreationDate(DateTime value)
        {
            Value = value;
        }

        public IActivityVisitor Accept(IActivityVisitor visitor) => visitor.Visit(this);
        public ITagVisitor Accept(ITagVisitor visitor) => visitor.Visit(this);
        public IAreaVisitor Accept(IAreaVisitor visitor) => visitor.Visit(this);
    }
}
