using System.Linq;
using TMS.Database.Entities.Tags;
using TMS.Layer;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Tags;

namespace TMS.Database.Commands.Tags
{
    public class SaveTagCommand : IQueryCommand<Tag, TagKey>
    {
        private readonly IEntityService<Tag, TagEntity> _entityService;

        public SaveTagCommand(IEntityService<Tag, TagEntity> entityService)
        {
            _entityService = entityService;
        }

        public Maybe<TagKey> ExecuteCommand(Tag data)
        {
            var entity = _entityService
                .Save<TagKey>(data, (k, entities) => entities.FirstOrDefault(e => e.Id == k.Identifier));

            return new Maybe<TagKey>(new TagKey(entity.Id));
        }
    }
}
