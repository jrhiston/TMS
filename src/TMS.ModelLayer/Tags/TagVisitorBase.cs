using System;
using System.Collections;
using System.Collections.Generic;
using TMS.ModelLayer.People;
using TMS.ModelLayer.Tags.CanSetOnActivities;

namespace TMS.ModelLayer.Tags
{
    public class TagVisitorBase : ITagVisitor
    {
        public virtual ITagVisitor Visit(CreationDate creationDate) => this;
        public virtual ITagVisitor Visit(Description description) => this;
        public virtual ITagVisitor Visit(Reusable reusable) => this;
        public virtual ITagVisitor Visit(CanSetOnActivityBase canSetOnActivityBase) => this;
        public virtual ITagVisitor Visit(Name name) => this;
        public virtual ITagVisitor Visit(TagKey tagKey) => this;
        public virtual ITagVisitor Visit(PersonKey personKey) => this;
        public virtual ITagVisitor Visit(ParentTag parentTag) => this;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public virtual IEnumerator<ITagElement> GetEnumerator()
        {
            yield break;
        }
    }
}
