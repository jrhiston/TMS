using System;
using TMS.ModelLayer.Activities;

namespace TMS.ModelLayer.Areas
{
    public class AreaKey : Key, IAreaElement, IActivityElement
    {
        public AreaKey(long id) : base(id)
        {
        }

        public IActivityVisitor Accept(IActivityVisitor visitor) => visitor.Visit(this);
        public IAreaVisitor Accept(IAreaVisitor visitor) => visitor.Visit(this);
    }
}
