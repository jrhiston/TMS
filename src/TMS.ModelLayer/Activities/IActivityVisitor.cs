using System.Collections.Generic;
using TMS.ModelLayer.Activities.Comments;
using TMS.ModelLayer.Areas;
using TMS.ModelLayer.People;
using TMS.ModelLayer.Tags;

namespace TMS.ModelLayer.Activities
{
    public interface IActivityVisitor : IEnumerable<IActivityElement>
    {
        IActivityVisitor Visit(Name data);
        IActivityVisitor Visit(Description data);
        IActivityVisitor Visit(ActivityKey data);
        IActivityVisitor Visit(Tag data);
        IActivityVisitor Visit(CreationDate data);
        IActivityVisitor Visit(ActivityComment activityComment);
        IActivityVisitor Visit(PersonKey data);
        IActivityVisitor Visit(AreaKey data);
    }
}
