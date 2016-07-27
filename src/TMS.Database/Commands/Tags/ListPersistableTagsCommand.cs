using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Database.Entities.Tags;
using TMS.Layer;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Tags;
using TMS.ModelLayerInterface.Tags.Data;
using TMS.ModelLayerInterface.Tags.Decorators;

namespace TMS.Database.Commands.Tags
{
    public class ListPersistableTagsCommand : IQueryCommand<TagFilterData, IEnumerable<IPersistableTag>>
    {
        private readonly IDatabaseContext<TagEntity> _context;
        private readonly IDecoratorFactory<PersistableTagData, ITag, IPersistableTag> _persistableTagFactory;
        private readonly IFactory<TagData, ITag> _tagFactory;
        private readonly IFactory<TagKeyData, ITagKey> _tagKeyFactory;

        public ListPersistableTagsCommand(IDatabaseContext<TagEntity> context,
            IDecoratorFactory<PersistableTagData, ITag, IPersistableTag> persistableTagFactory,
            IFactory<TagData, ITag> tagFactory,
            IFactory<TagKeyData, ITagKey> tagKeyFactory)
        {
            _context = context;
            _persistableTagFactory = persistableTagFactory;
            _tagFactory = tagFactory;
            _tagKeyFactory = tagKeyFactory;
        }

        public Maybe<IEnumerable<IPersistableTag>> ExecuteCommand(TagFilterData data)
        {
            var activityId = data.ActivityKey?.Identifier;

            var tags = _context.Entities.Where(item => 
                    (data.TagName == null || item.Name == data.TagName)
                &&  (data.Reusable == null || item.Reusable == data.Reusable)
                &&  (activityId == null || item.Activities.Any(a => a.ActivityId == activityId)));

            if (tags == null)
                return new Maybe<IEnumerable<IPersistableTag>>();

            var result = new List<IPersistableTag>();

            foreach (var tag in tags)
            {
                var tagData = new TagData
                {
                    Name = tag.Name,
                    Created = tag.Created,
                    Description = tag.Description,
                    CanSetOnActivity = tag.CanSetOnActivity,
                    Reusable = tag.Reusable
                };

                var createdTag = _tagFactory.Create(tagData);

                var persistableTagData = new PersistableTagData
                {
                    Key = _tagKeyFactory.Create(new TagKeyData { Identifier = tag.Id })
                };

                var persistableTag = _persistableTagFactory.Create(persistableTagData, createdTag);

                result.Add(persistableTag);
            }

            return new Maybe<IEnumerable<IPersistableTag>>(result);
        }
    }
}
