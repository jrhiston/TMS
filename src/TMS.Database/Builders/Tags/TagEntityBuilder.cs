using System;
using System.Linq;
using TMS.Data.Entities.Tags;
using TMS.Layer.Builders;
using TMS.Layer.Entities;
using TMS.Layer.Extensions;
using TMS.ModelLayer;
using TMS.ModelLayer.People;
using TMS.ModelLayer.Tags;
using TMS.ModelLayer.Tags.CanSetOnActivities;

namespace TMS.Database.Builders.Tags
{
    public class TagEntityBuilder : TagVisitorBase, IEntityBuilder<Tag, TagEntity>
    {
        private TagEntity _entity;
        private readonly IEntityCollectionService<Tag, TagToTagEntity> _tagCollectionService;

        public TagEntityBuilder(IEntityCollectionService<Tag, TagToTagEntity> tagCollectionService)
        {
            _tagCollectionService = tagCollectionService;
        }

        public TagEntity Create(Tag data)
        {
            _entity = new TagEntity();

            data.Accept(this);

            return _entity;
        }

        public override ITagVisitor Visit(Reusable reusable)
        {
            _entity.Reusable = reusable.Value;
            return this;
        }

        public override ITagVisitor Visit(CreationDate creationDate)
        {
            _entity.Created = creationDate.Value;
            return this;
        }

        public override ITagVisitor Visit(Description description)
        {
            _entity.Description = description.Value;
            return this;
        }

        public override ITagVisitor Visit(CanSetOnActivityBase canSetOnActivityBase)
        {
            _entity.CanSetOnActivity = canSetOnActivityBase.Value;
            return this;
        }

        public override ITagVisitor Visit(Name name)
        {
            _entity.Name = name.Value;
            return this;
        }

        public override ITagVisitor Visit(PersonKey personKey)
        {
            _entity.AuthorId = personKey.Identifier;
            return this;
        }

        public override ITagVisitor Visit(ParentTag parentTag)
        {
            _tagCollectionService.AddOrUpdate<TagKey>(_entity.ParentTags,
                parentTag.Tag,
                t => CreateNewTagLink(t),
                (s, k) => s.ParentTagId == k.Identifier);

            return this;
        }

        public void Update(Tag data, TagEntity existing)
        {
            _entity = existing;

            existing.ParentTags.DeleteMissing(
                data.OfType<Tag>(), 
                (t, e) => t.OfType<TagKey>().Single().Identifier == e.ParentTagId);

            data.Accept(this);
        }

        private TagToTagEntity CreateNewTagLink(Tag data)
        {
            var tagId = data
                .OfType<TagKey>()
                .FirstOrDefault();
            
            return new TagToTagEntity
            {
                ChildTagId = _entity.Id,
                ParentTagId = tagId.Identifier,
            };
        }
    }
}
