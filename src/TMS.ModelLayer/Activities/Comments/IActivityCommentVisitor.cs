using System.Collections.Generic;
using TMS.ModelLayer.People;

namespace TMS.ModelLayer.Activities.Comments
{
    public interface IActivityCommentVisitor : IEnumerable<IActivityCommentElement>
    {
        IActivityCommentVisitor Visit(ActivityCommentKey activityCommentKey);
        IActivityCommentVisitor Visit(Description description);
        IActivityCommentVisitor Visit(CreationDate creationDate);
        IActivityCommentVisitor Visit(PersonKey personKey);
    }
}
