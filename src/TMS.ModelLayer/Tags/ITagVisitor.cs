using System.Collections.Generic;
using TMS.ModelLayer.People;
using TMS.ModelLayer.Tags.CanSetOnActivities;

namespace TMS.ModelLayer.Tags
{
    public interface ITagVisitor : IEnumerable<ITagElement>
    {
        ITagVisitor Visit(TagKey tagKey);
        ITagVisitor Visit(Name name);
        ITagVisitor Visit(CreationDate creationDate);
        ITagVisitor Visit(CanSetOnActivityBase canSetOnActivityBase);
        ITagVisitor Visit(PersonKey personKey);
        ITagVisitor Visit(Description description);
        ITagVisitor Visit(Reusable reusable);
    }
}
