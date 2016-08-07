using System.Collections.Generic;
using System.Linq;
using TMS.Database.Entities.Tags;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Tags;

namespace TMS.Database.Commands.Tags
{
    public class ListTagsCommand : IQueryCommand<TagFilterData, IEnumerable<Tag>>
    {
        private readonly IDatabaseContext<TagEntity> _context;
        private readonly IConverter<TagEntity, Tag> _converter;

        public ListTagsCommand(IDatabaseContext<TagEntity> context,
            IConverter<TagEntity, Tag> converter)
        {
            _context = context;
            _converter = converter;
        }

        public Maybe<IEnumerable<Tag>> ExecuteCommand(TagFilterData data)
        {
            var activityId = data.ActivityKey?.Identifier;

            var tags = _context.Entities.Where(item => 
                    (data.TagName == null || item.Name == data.TagName)
                &&  (data.Reusable == null || item.Reusable == data.Reusable)
                &&  (activityId == null || item.Activities.Any(a => a.ActivityId == activityId)));

            if (!tags.Any())
                return new Maybe<IEnumerable<Tag>>();

            return new Maybe<IEnumerable<Tag>>(tags.ToList().Select(t => _converter.Convert(t).Single()));
        }
    }
}
