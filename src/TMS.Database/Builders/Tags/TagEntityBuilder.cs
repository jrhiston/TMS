using TMS.Database.Entities.Tags;
using TMS.Layer.Builders;
using TMS.ModelLayer;
using TMS.ModelLayer.People;
using TMS.ModelLayer.Tags;
using TMS.ModelLayer.Tags.CanSetOnActivities;

namespace TMS.Database.Builders.Tags
{
    public class TagEntityBuilder : TagVisitorBase, IEntityBuilder<Tag, TagEntity>
    {
        private TagEntity _entity;

        public TagEntity Create(Tag data)
        {
            _entity = new TagEntity();

            data.Accept(this);

            return _entity;
        }

        public override ITagVisitor Visit(TagKey tagKey)
        {
            _entity.Id = tagKey.Identifier;
            return this;
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

        public void Update(Tag data, TagEntity existing)
        {
            _entity = existing;

            data.Accept(this);
        }
    }
}
