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
        private readonly IDatabaseContextFactory<ActivityEntity> _contextFactory;
        private readonly IFactory<ActivityKeyData, IActivityKey> _activityKeyFactory;
        private readonly IConverter<IPersistableActivity, ActivityEntity> _activityToEntityConverter;

        public SavePersistableActivityCommandFactory(IDatabaseContextFactory<ActivityEntity> contextFactory,
            IConverter<IPersistableActivity, ActivityEntity> activityToEntityConverter,
            IFactory<ActivityKeyData, IActivityKey> activityKeyFactory)
        {
            _contextFactory = contextFactory;
            _activityToEntityConverter = activityToEntityConverter;
            _activityKeyFactory = activityKeyFactory;
        }

        public IQueryCommand<IPersistableActivity, IActivityKey> Create() => new SavePersistableActivityCommand(_contextFactory, _activityToEntityConverter, _activityKeyFactory);
    }
}
