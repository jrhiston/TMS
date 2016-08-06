using System;
using TMS.Layer.ModelObjects;
using TMS.ModelLayer.Activities;

namespace TMS.ModelLayer.Areas
{
    public class Area : AggregateRoot<IAreaElement, IAreaVisitor>, IAreaElement
    {
        public Area(params IAreaElement[] elements) : base(elements)
        {
        }
    }
}
