using System;
using TMS.Layer.ModelObjects;

namespace TMS.ModelLayer.Activities.Comments
{
    public class ActivityComment : AggregateRoot<IActivityCommentElement, IActivityCommentVisitor>, IActivityCommentElement, IActivityElement
    {
        public ActivityComment(params IActivityCommentElement[] elements) : base(elements)
        {
        }

        public IActivityVisitor Accept(IActivityVisitor visitor) => visitor.Visit(this);
    }
}
