using System.Linq;
using TMS.Data.Entities.Activities;
using TMS.Layer;
using TMS.Layer.Entities;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Activities;

namespace TMS.Database.Commands.Activities
{
    public class SaveActivityCommand : IQueryCommand<Activity, ActivityKey>
    {
        private readonly IEntityService<Activity, ActivityEntity> _entityService;

        public SaveActivityCommand(IEntityService<Activity, ActivityEntity> entityService)
        {
            _entityService = entityService;
        }

        public Maybe<ActivityKey> ExecuteCommand(Activity data)
        {
            var entity = _entityService.Save<ActivityKey>(data, (k, entities) => entities.FirstOrDefault(e => e.Id == k.Identifier));

            return new Maybe<ActivityKey>(new ActivityKey(entity.Id));
        }
    }
}
