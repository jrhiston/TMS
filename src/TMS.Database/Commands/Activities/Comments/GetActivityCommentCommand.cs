using System.Linq;
using TMS.Data.Entities.Activities.Comments;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Data;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Activities.Comments;

namespace TMS.Database.Commands.Activities.Comments
{
    public class GetActivityCommentCommand : IQueryCommand<ActivityCommentKey, ActivityComment>
    {
        private readonly IConverter<ActivityCommentEntity, ActivityComment> _entityConverter;
        private readonly IDataContextFactory<ActivityCommentEntity> _contextFactory;

        public GetActivityCommentCommand(IDataContextFactory<ActivityCommentEntity> contextFactory,
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
