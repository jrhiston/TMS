using TMS.Database.Commands.Activities;
using TMS.Database.Entities.Activities;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Activities.Decorators;

namespace TMS.Database.Factories.Activities
{
    public class SavePersistableActivityCommandFactory : IQueryFactory<IQueryCommand<IPersistableActivity, IActivityKey>>
    {
        private readonly IDatabaseContext<ActivityEntity> _activitiesContext;
        private readonly IFactory<ActivityKeyData, IActivityKey> _activityKeyFactory;
        private readonly IConverter<IPersistableActivity, ActivityEntity> _activityToEntityConverter;

        public SavePersistableActivityCommandFactory(IDatabaseContext<ActivityEntity> activitiesContext,
            IConverter<IPersistableActivity, ActivityEntity> activityToEntityConverter,
            IFactory<ActivityKeyData, IActivityKey> activityKeyFactory)
        {
            _activitiesContext = activitiesContext;
            _activityToEntityConverter = activityToEntityConverter;
            _activityKeyFactory = activityKeyFactory;
        }

        public IQueryCommand<IPersistableActivity, IActivityKey> Create() => new SavePersistableActivityCommand(_activitiesContext, _activityToEntityConverter, _activityKeyFactory);
    }
}
