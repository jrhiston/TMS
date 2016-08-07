using System;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.Activities.Comments;
using TMS.ModelLayer.Areas;
using TMS.ModelLayer.Tags;

namespace TMS.ModelLayer.People
{
    public class PersonKey : Key, IActivityElement, IAreaElement, IPersonElement, ITagElement, IActivityCommentElement
    {
        public PersonKey(long id) : base(id)
        {
        }

        public ITagVisitor Accept(ITagVisitor visitor) => visitor.Visit(this);

        public IActivityCommentVisitor Accept(IActivityCommentVisitor visitor) => visitor.Visit(this);
        public IActivityVisitor Accept(IActivityVisitor visitor) => visitor.Visit(this);
        public IAreaVisitor Accept(IAreaVisitor visitor) => visitor.Visit(this);
        public IPersonVisitor Accept(IPersonVisitor visitor) => visitor.Visit(this);
    }
}
