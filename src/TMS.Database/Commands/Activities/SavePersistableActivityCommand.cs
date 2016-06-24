using System;
using System.Linq;
using TMS.Database.Entities.Activities;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Activities.Decorators;

namespace TMS.Database.Commands.Activities
{
    public class SavePersistableActivityCommand : IQueryCommand<IPersistableActivity, IActivityKey>
    {
        private readonly IDatabaseContext<ActivityEntity> _activitiesContext;
        private readonly IFactory<ActivityKeyData, IActivityKey> _activityKeyFactory;
        private readonly IConverter<IPersistableActivity, ActivityEntity> _activityToEntityConverter;

        public SavePersistableActivityCommand(IDatabaseContext<ActivityEntity> activitiesContext,
            IConverter<IPersistableActivity, ActivityEntity> activityToEntityConverter,
            IFactory<ActivityKeyData, IActivityKey> activityKeyFactory)
        {
            _activitiesContext = activitiesContext;
            _activityToEntityConverter = activityToEntityConverter;
            _activityKeyFactory = activityKeyFactory;
        }

        public Maybe<IActivityKey> ExecuteCommand(IPersistableActivity data)
        {
            var newEntity = _activityToEntityConverter
                .Convert(data).FirstOrDefault();

            if (newEntity != null)
            {
                var matchingEntity = _activitiesContext.Entities.FirstOrDefault(item => item.Id == newEntity.Id);

                if (matchingEntity != null)
                {
                    matchingEntity.Accept(newEntity);
                }
                else
                {
                    newEntity = _activitiesContext.Entities.Add(newEntity).Entity;
                }

                _activitiesContext.SaveChanges();

                return new Maybe<IActivityKey>(_activityKeyFactory.Create(new ActivityKeyData
                {
                    Identifier = newEntity.Id
                }));
            }

            return new Maybe<IActivityKey>();
        }
    }
}
