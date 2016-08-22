using System.Collections.Generic;
using System.Linq;
using TMS.Data.Entities.Activities.Comments;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Data;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Activities.Comments;

namespace TMS.Database.Commands.Activities.Comments
{
    public class ListActivityCommentsCommand : IQueryCommand<ActivityCommentFilterData, IEnumerable<ActivityComment>>
    {
        private readonly IDataContextFactory<ActivityCommentEntity> _contextFactory;
        private readonly IConverter<ActivityCommentEntity, ActivityComment> _converter;

        public ListActivityCommentsCommand(IDataContextFactory<ActivityCommentEntity> contextFactory,
            IConverter<ActivityCommentEntity, ActivityComment> converter)
        {
            _contextFactory = contextFactory;
            _converter = converter;
        }

        public Maybe<IEnumerable<ActivityComment>> ExecuteCommand(ActivityCommentFilterData data)
        {
            using (var context = _contextFactory.Create())
            {
                if (data == null)
                    return new Maybe<IEnumerable<ActivityComment>>();

                var activityId = data.ActivityKey.Identifier;

                var comments = context
                    .Entities
                    .Where(item => item.ActivityId == activityId);

                return new Maybe<IEnumerable<ActivityComment>>(comments
                    .Select(area => _converter.Convert(area))
                    .SelectMany(item => item)
                    .ToList());
            }
        }
    }
}
