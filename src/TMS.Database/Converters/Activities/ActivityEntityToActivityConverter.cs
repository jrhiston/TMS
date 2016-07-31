using System.Linq;
using TMS.Database.Entities.Activities;
using TMS.Database.Entities.Tags;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Activities.Decorators;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Data;
using TMS.ModelLayerInterface.Tags;

namespace TMS.Database.Converters.Activities
{
    public class ActivityEntityToActivityConverter : IConverter<ActivityEntity, IActivity>
    {
        private readonly IFactory<ActivityData, IActivity> _activityFactory;
        private readonly IFactory<ActivityKeyData, IActivityKey> _activityKeyFactory;
        private readonly IDecoratorFactory<OwnedActivityData, IActivity, IOwnedActivity> _ownedActivityFactory;
        private readonly IDecoratorFactory<PersistableActivityData, IOwnedActivity, IPersistableActivity> _persistableActivityFactory;
        private readonly IFactory<PersonKeyData, IPersonKey> _personKeyFactory;
        private readonly IConverter<TagEntity, ITag> _tagConverter;
        private readonly IDecoratorFactory<TaggableActivityData, IPersistableActivity, ITaggableActivity> _taggableActivityFactory;

        public ActivityEntityToActivityConverter(IFactory<ActivityData, IActivity> activityFactory,
            IFactory<ActivityKeyData, IActivityKey> activityKeyFactory,
            IDecoratorFactory<OwnedActivityData, IActivity, IOwnedActivity> ownedActivityFactory,
            IDecoratorFactory<PersistableActivityData, IOwnedActivity, IPersistableActivity> persistableActivityFactory,
            IDecoratorFactory<TaggableActivityData, IPersistableActivity, ITaggableActivity> taggableActivityFactory,
            IFactory<PersonKeyData, IPersonKey> personKeyFactory,
            IConverter<TagEntity, ITag> tagConverter)
        {
            _activityFactory = activityFactory;
            _activityKeyFactory = activityKeyFactory;
            _persistableActivityFactory = persistableActivityFactory;
            _ownedActivityFactory = ownedActivityFactory;
            _taggableActivityFactory = taggableActivityFactory;
            _personKeyFactory = personKeyFactory;
            _tagConverter = tagConverter;
        }

        public Maybe<IActivity> Convert(ActivityEntity input)
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
                    Identifier = input.OwnerId
                })
            }, activity);

            var persistableActivity = _persistableActivityFactory.Create(new PersistableActivityData
            {
                Key = activityKey
            }, ownedActivity);

            if (input.Tags != null && input.Tags.Any())
            {
                var taggedActivity = _taggableActivityFactory.Create(new TaggableActivityData
                {
                    Tags = input.Tags.SelectMany(t => _tagConverter.Convert(t.Tag))
                }, persistableActivity);

                return new Maybe<IActivity>(taggedActivity);
            }

            return new Maybe<IActivity>(persistableActivity);
        }
    }
}
