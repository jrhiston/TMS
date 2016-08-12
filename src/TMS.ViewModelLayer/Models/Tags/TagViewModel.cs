using System;
using TMS.ModelLayer;
using TMS.ModelLayer.People;
using TMS.ModelLayer.Tags;
using TMS.ModelLayer.Tags.CanSetOnActivities;

namespace TMS.ViewModelLayer.Models.Tags
{
    public class TagViewModel : TagVisitorBase
    {
        public bool CanSetOnActivity { get; private set; }
        public DateTime Created { get; private set; }
        public string Description { get; private set; }
        public string Name { get; private set; }
        public long Identifier { get; private set; }
        public long AuthorId { get; private set; }

        public override ITagVisitor Visit(TagKey tagKey)
        {
            Identifier = tagKey.Identifier;
            return this;
        }

        public override ITagVisitor Visit(CanSetOnActivityBase canSetOnActivityBase)
        {
            CanSetOnActivity = canSetOnActivityBase.Value;
            return this;
        }

        public override ITagVisitor Visit(Description description)
        {
            Description = description.Value;
            return this;
        }

        public override ITagVisitor Visit(Name name)
        {
            Name = name.Value;
            return this;
        }

        public override ITagVisitor Visit(CreationDate creationDate)
        {
            Created = creationDate.Value;
            return this;
        }

        public override ITagVisitor Visit(PersonKey personKey)
        {
            AuthorId = personKey.Identifier;
            return this;
        }
    }
}
