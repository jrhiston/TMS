using TMS.Database.Entities.Activities;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Activities.Decorators;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Data;

namespace TMS.Database.Converters.Activities
{
    public class ActivityEntityToPersistableActivityConverter : IConverter<ActivityEntity, IPersistableActivity>
    {
        private readonly IFactory<ActivityData, IActivity> _activityFactory;
        private readonly IFactory<ActivityKeyData, IActivityKey> _activityKeyFactory;
        private readonly IDecoratorFactory<OwnedActivityData, IActivity, IOwnedActivity> _ownedActivityFactory;
        private readonly IDecoratorFactory<PersistableActivityData, IOwnedActivity, IPersistableActivity> _persistableActivityFactory;
        private readonly IFactory<PersonKeyData, IPersonKey> _personKeyFactory;

        public ActivityEntityToPersistableActivityConverter(IFactory<ActivityData, IActivity> activityFactory,
            IFactory<ActivityKeyData, IActivityKey> activityKeyFactory,
            IDecoratorFactory<OwnedActivityData, IActivity, IOwnedActivity> ownedActivityFactory,
            IDecoratorFactory<PersistableActivityData, IOwnedActivity, IPersistableActivity> persistableActivityFactory,
            IFactory<PersonKeyData, IPersonKey> personKeyFactory)
        {
            _activityFactory = activityFactory;
            _activityKeyFactory = activityKeyFactory;
            _persistableActivityFactory = persistableActivityFactory;
            _ownedActivityFactory = ownedActivityFactory;
            _personKeyFactory = personKeyFactory;
        }

        public Maybe<IPersistableActivity> Convert(ActivityEntity input)
        {
            var activity = _activityFactory.Create(new ActivityData
            {
                Title = input.Title,
                Description = input.Description,
                Created = input.Created
            });

            var activityKey = _activityKeyFactory.Create(new ActivityKeyData
            {
                Identifier = input.Id
            });

            var ownedActivity = _ownedActivityFactory.Create(new OwnedActivityData
            {
                OwnerKey = _personKeyFactory.Create(new PersonKeyData
                {
                    Identifier = input.Owner.Id
                })
            }, activity);

            var persistableActivity = _persistableActivityFactory.Create(new PersistableActivityData
            {
                Key = activityKey
            }, ownedActivity);

            return new Maybe<IPersistableActivity>(persistableActivity);
        }
    }
}
