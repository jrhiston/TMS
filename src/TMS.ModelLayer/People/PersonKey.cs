using System;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.Areas;

namespace TMS.ModelLayer.People
{
    public class PersonKey : Key, IActivityElement, IAreaElement, IPersonElement
    {
        public PersonKey(long id) : base(id)
        {
        }

        public IActivityVisitor Accept(IActivityVisitor visitor) => visitor.Visit(this);
        public IAreaVisitor Accept(IAreaVisitor visitor) => visitor.Visit(this);
        public IPersonVisitor Accept(IPersonVisitor visitor) => visitor.Visit(this);
    }
}
