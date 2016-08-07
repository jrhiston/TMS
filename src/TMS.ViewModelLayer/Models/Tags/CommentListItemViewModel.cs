using System;
using TMS.ModelLayer;
using TMS.ModelLayer.People;
using TMS.ModelLayer.Tags;

namespace TMS.ViewModelLayer.Models.Tags
{
    public class CommentListItemViewModel : TagVisitorBase
    {
        public long ParentId { get; set; }
        public long Id { get; set; }
        public string Description { get; private set; }

        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public long CreatorId { get; private set; }

        public override ITagVisitor Visit(TagKey tagKey)
        {
            Id = tagKey.Identifier;
            return this;
        }

        public override ITagVisitor Visit(Description description)
        {
            Description = description.Value;
            return this;
        }

        public override ITagVisitor Visit(CreationDate creationDate)
        {
            Created = creationDate.Value;
            return this;
        }

        public override ITagVisitor Visit(PersonKey personKey)
        {
            CreatorId = personKey.Identifier;
            return this;
        }
    }
}
