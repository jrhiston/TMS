using System;
using TMS.Layer.ModelObjects;
using TMS.ModelLayer.Areas;

namespace TMS.ModelLayer.Activities
{
    public class Activity : AggregateRoot<IActivityElement, IActivityVisitor>, IActivityElement, IAreaElement
    {
        public Activity(params IActivityElement[] elements) : base(elements)
        {
        }

        public IAreaVisitor Accept(IAreaVisitor visitor) => visitor.Visit(this);
    }
}
