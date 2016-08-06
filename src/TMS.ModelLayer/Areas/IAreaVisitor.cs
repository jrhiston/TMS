using System.Collections.Generic;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.People;

namespace TMS.ModelLayer.Areas
{
    public interface IAreaVisitor : IEnumerable<IAreaElement>
    {
        IAreaVisitor Visit(AreaKey areaKey);
        IAreaVisitor Visit(Name name);
        IAreaVisitor Visit(Description description);
        IAreaVisitor Visit(CreationDate creationDate);
        IAreaVisitor Visit(Activity activity);
        IAreaVisitor Visit(PersonKey personKey);
    }
}
