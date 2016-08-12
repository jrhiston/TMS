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
        private readonly IDatabaseContextFactory<TagEntity> _contextFactory;
        private readonly IConverter<TagEntity, Tag> _converter;

        public ListTagsCommand(IDatabaseContextFactory<TagEntity> contextFactory,
            IConverter<TagEntity, Tag> converter)
        {
            _contextFactory = contextFactory;
            _converter = converter;
        }

        public Maybe<IEnumerable<Tag>> ExecuteCommand(TagFilterData data)
        {
            var activityId = data.ActivityKey?.Identifier;
            var parentTagId = data.ParentTagKey?.Identifier;
            var childTagId = data.ChildTagKey?.Identifier;
            var authorId = data.CreatorKey?.Identifier;
            var canSetOnActivity = data.CanSetOnActivity;

            using (var context = _contextFactory.Create())
            {
                var tags = context.Entities.Where(item =>
                        (data.TagName == null || item.Name == data.TagName)
                    && (data.Reusable == null || item.Reusable == data.Reusable)
                    && (parentTagId == null || item.ParentTags.Any(t => t.ParentTagId == parentTagId))
                    && (childTagId == null || item.ChildTags.Any(t => t.ChildTagId == childTagId))
                    && (authorId == null || item.AuthorId == authorId)
                    && (canSetOnActivity == null || item.CanSetOnActivity == canSetOnActivity)
                    && (activityId == null || item.Activities.Any(a => a.ActivityId == activityId)));

                if (!tags.Any())
                    return new Maybe<IEnumerable<Tag>>();

                return new Maybe<IEnumerable<Tag>>(tags.ToList().Select(t => _converter.Convert(t).Single()));
            }
        }
    }
}
