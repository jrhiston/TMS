using System;
using System.Linq;
using TMS.Database.Entities.Activities;
using TMS.Database.Entities.Activities.Comments;
using TMS.Database.Entities.Tags;
using TMS.Layer.Builders;
using TMS.Layer.Extensions;
using TMS.ModelLayer;
using TMS.ModelLayer.Activities;
using TMS.ModelLayer.Activities.Comments;
using TMS.ModelLayer.Areas;
using TMS.ModelLayer.People;
using TMS.ModelLayer.Tags;

namespace TMS.Database.Builders.Activities
{
    public class ActivityEntityBuilder : ActivityVisitorBase, IEntityBuilder<Activity, ActivityEntity>
    {
        private ActivityEntity _entity;
        
        private readonly IEntityCollectionService<Tag, TagActivityEntity> _tagCollectionService;
        private readonly IEntityBuilder<Tag, TagEntity> _tagEntityBuilder;
        private readonly IEntityCollectionService<ActivityComment, ActivityCommentEntity> _commentCollectionService;
        private readonly IEntityBuilder<ActivityComment, ActivityCommentEntity> _commentBuilder;

        public ActivityEntityBuilder(IEntityCollectionService<Tag, TagActivityEntity> tagCollectionService,
            IEntityCollectionService<ActivityComment, ActivityCommentEntity> commentCollectionService,
            IEntityBuilder<Tag, TagEntity> tagEntityBuilder,
            IEntityBuilder<ActivityComment, ActivityCommentEntity> commentBuilder)
        {
            _tagCollectionService = tagCollectionService;
            _tagEntityBuilder = tagEntityBuilder;
            _commentCollectionService = commentCollectionService;
            _commentBuilder = commentBuilder;
        }

        public override IActivityVisitor Visit(ActivityComment activityComment)
        {
            _commentCollectionService.AddOrUpdate<ActivityCommentKey>(_entity.Comments,
                activityComment,
                c => AddOrUpdateComment(c),
                (s, k) => s.Id == k.Identifier);
            return this;
        }

        public override IActivityVisitor Visit(Name data)
        {
            _entity.Title = data.Value;
            return this;
        }

        public override IActivityVisitor Visit(Description data)
        {
            _entity.Description = data.Value;
            return this;
        }

        public override IActivityVisitor Visit(Tag data)
        {
            _tagCollectionService.AddOrUpdate<TagKey>(_entity.Tags, 
                data, 
                t => CreateNewTagLink(t),
                (s, k) => s.TagId == k.Identifier);

            return this;
        }

        public override IActivityVisitor Visit(CreationDate data)
        {
            _entity.Created = data.Value;
            return this;
        }

        public override IActivityVisitor Visit(PersonKey data)
        {
            _entity.OwnerId = data.Identifier;
            return this;
        }

        public override IActivityVisitor Visit(AreaKey data)
        {
            _entity.AreaId = data.Identifier;
            return this;
        }

        public void SetExistingEntity(ActivityEntity existingEntity)
        {
            _entity = existingEntity;
        }

        public ActivityEntity Create(Activity data)
        {
            _entity = new ActivityEntity();

            data.Accept(this);

            return _entity;
        }

        public void Update(Activity data, ActivityEntity existing)
        {
            _entity = existing;

            existing.Tags.DeleteMissing(data.OfType<Tag>(), (t, e) => t.OfType<TagKey>().Single().Identifier == e.TagId);

            data.Accept(this);
        }

        private TagActivityEntity CreateNewTagLink(Tag data)
        {
            var tagId = data.OfType<TagKey>().FirstOrDefault();

            if (tagId == null || tagId.Identifier <= 0)
            {
                return new TagActivityEntity
                {
                    Activity = _entity,
                    Tag = _tagEntityBuilder.Create(data)
                };
            }

            return new TagActivityEntity
            {
                ActivityId = _entity.Id,
                TagId = tagId.Identifier,
            };
        }

        private ActivityCommentEntity AddOrUpdateComment(ActivityComment data)
        {
            var tagId = data.OfType<ActivityComment>().OfType<ActivityCommentKey>().FirstOrDefault();

            if (tagId == null || tagId.Identifier <= 0)
            {
                return _commentBuilder.Create(data);
            }

            var existing = _entity.Comments.Single(c => c.Id == tagId.Identifier);

            _commentBuilder.Update(data, existing);

            return existing;
        }
    }
}
