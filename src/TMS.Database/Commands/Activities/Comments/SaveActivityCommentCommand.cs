using System.Linq;
using TMS.Database.Entities.Activities.Comments;
using TMS.Layer;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Activities.Comments;

namespace TMS.Database.Commands.Activities.Comments
{
    public class SaveActivityCommentCommand : IQueryCommand<ActivityComment, ActivityCommentKey>
    {
        private readonly IEntityService<ActivityComment, ActivityCommentEntity> _entityService;

        public SaveActivityCommentCommand(IEntityService<ActivityComment, ActivityCommentEntity> entityService)
        {
            _entityService = entityService;
        }

        public Maybe<ActivityCommentKey> ExecuteCommand(ActivityComment data)
        {
            var entity = _entityService.Save<ActivityCommentKey>(data, (k, entities) => entities.FirstOrDefault(e => e.Id == k.Identifier));

            return new Maybe<ActivityCommentKey>(new ActivityCommentKey(entity.Id));
        }
    }
}
