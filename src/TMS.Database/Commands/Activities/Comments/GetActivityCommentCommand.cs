using System.Linq;
using TMS.Database.Entities.Activities.Comments;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Activities.Comments;

namespace TMS.Database.Commands.Activities.Comments
{
    public class GetActivityCommentCommand : IQueryCommand<ActivityCommentKey, ActivityComment>
    {
        private readonly IConverter<ActivityCommentEntity, ActivityComment> _entityConverter;
        private readonly IDatabaseContextFactory<ActivityCommentEntity> _contextFactory;

        public GetActivityCommentCommand(IDatabaseContextFactory<ActivityCommentEntity> contextFactory,
            IConverter<ActivityCommentEntity, ActivityComment> entityConverter)
        {
            _contextFactory = contextFactory;
            _entityConverter = entityConverter;
        }

        public Maybe<ActivityComment> ExecuteCommand(ActivityCommentKey data)
        {
            using (var context = _contextFactory.Create())
            {
                return _entityConverter.Convert(context.Entities.Single(item => item.Id == data.Identifier));
            }
        }
    }
}
