using System.Collections;
using System.Collections.Generic;
using TMS.ModelLayer.People;

namespace TMS.ModelLayer.Activities.Comments
{
    public abstract class ActivityCommentVisitorBase : IActivityCommentVisitor
    {
        public virtual IActivityCommentVisitor Visit(ActivityCommentKey activityCommentKey) => this;
        public virtual IActivityCommentVisitor Visit(Description description) => this;
        public virtual IActivityCommentVisitor Visit(CreationDate creationDate) => this;
        public virtual IActivityCommentVisitor Visit(PersonKey personKey) => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public virtual IEnumerator<IActivityCommentElement> GetEnumerator()
        {
            yield break;
        }
    }
}
