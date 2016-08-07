using System;
using TMS.ModelLayer;
using TMS.ModelLayer.Activities.Comments;
using TMS.ModelLayer.People;

namespace TMS.ViewModelLayer.Models.Tags
{
    public class CommentListItemViewModel : ActivityCommentVisitorBase
    {
        public long ParentId { get; set; }
        public long Id { get; set; }
        public string Description { get; private set; }

        public string Creator { get; set; }
        public DateTime Created { get; set; }
        public long CreatorId { get; private set; }

        public override IActivityCommentVisitor Visit(ActivityCommentKey activityCommentKey)
        {
            Id = activityCommentKey.Identifier;
            return this;
        }

        public override IActivityCommentVisitor Visit(Description description)
        {
            Description = description.Value;
            return this;
        }

        public override IActivityCommentVisitor Visit(CreationDate creationDate)
        {
            Created = creationDate.Value;
            return this;
        }

        public override IActivityCommentVisitor Visit(PersonKey personKey)
        {
            CreatorId = personKey.Identifier;
            return this;
        }
    }
}
