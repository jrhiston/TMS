using TMS.Data.Entities.Activities.Comments;
using TMS.Layer.Builders;
using TMS.ModelLayer;
using TMS.ModelLayer.Activities.Comments;
using TMS.ModelLayer.People;

namespace TMS.Database.Builders.Activities.Comments
{
    public class ActivityCommentEntityBuilder : ActivityCommentVisitorBase, IEntityBuilder<ActivityComment, ActivityCommentEntity>
    {
        private ActivityCommentEntity _entity;

        public override IActivityCommentVisitor Visit(ActivityCommentKey activityCommentKey)
        {
            _entity.Id = activityCommentKey.Identifier;
            return this;
        }

        public override IActivityCommentVisitor Visit(CreationDate creationDate)
        {
            _entity.Created = creationDate.Value;
            return this;
        }

        public override IActivityCommentVisitor Visit(PersonKey personKey)
        {
            _entity.AuthorId = personKey.Identifier;
            return this;
        }

        public override IActivityCommentVisitor Visit(Description description)
        {
            _entity.Description = description.Value;
            return this;
        }

        public ActivityCommentEntity Create(ActivityComment data)
        {
            _entity = new ActivityCommentEntity();

            data.Accept(this);

            return _entity;
        }

        public void Update(ActivityComment data, ActivityCommentEntity existing)
        {
            _entity = existing;

            data.Accept(this);
        }
    }
}
