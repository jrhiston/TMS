using TMS.Database.Entities.Tags;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.ModelLayerInterface.Tags;
using TMS.ModelLayerInterface.Tags.Data;
using TMS.ModelLayerInterface.Tags.Decorators;

namespace TMS.Database.Converters.Tags
{
    public class TagEntityToTagConverter : IConverter<TagEntity, ITag>
    {
        private readonly IDecoratorFactory<PersistableTagData, ITag, IPersistableTag> _persistableTagFactory;
        private readonly IFactory<TagData, ITag> _tagFactory;
        private readonly IFactory<TagKeyData, ITagKey> _tagKeyFactory;

        public TagEntityToTagConverter(IFactory<TagData, ITag> tagFactory,
            IDecoratorFactory<PersistableTagData, ITag, IPersistableTag> persistableTagFactory,
            IFactory<TagKeyData, ITagKey> tagKeyFactory)
        {
            _tagFactory = tagFactory;
            _persistableTagFactory = persistableTagFactory;
            _tagKeyFactory = tagKeyFactory;
        }

        public Maybe<ITag> Convert(TagEntity tagEntity)
        {
            var tag = _tagFactory.Create(new TagData
            {
                Name = tagEntity.Name,
                Created = tagEntity.Created,
                Description = tagEntity.Description,
                CanSetOnActivity = tagEntity.CanSetOnActivity,
                Reusable = tagEntity.Reusable
            });

            return new Maybe<ITag>(_persistableTagFactory.Create(new PersistableTagData
            {
                Key = _tagKeyFactory.Create(new TagKeyData { Identifier = tagEntity.Id })
            }, tag));
        }
    }
}
