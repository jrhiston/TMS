using System;
using System.Linq;
using TMS.Layer.Creators;
using TMS.Layer.Factories;
using TMS.Layer.Persistence;
using TMS.Layer.Readers;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Activities.Decorators;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayerInterface.Areas.Decorators;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Decorators;
using TMS.ViewModelLayer.Models.Activities.Pages;

namespace TMS.ApplicationLayer.Activities
{
    public class ActivityCreator : ICreator<Tuple<CreateActivityPageModel, IPersonKey>>
    {
        private readonly IDecoratorFactory<ActivityAreaData, IActivity, IActivityArea> _activityAreaFactory;
        private readonly IFactory<ActivityData, IActivity> _activityFactory;
        private readonly IWriter<IPersistableActivity, IActivityKey> _activityWriter;
        private readonly IFactory<AreaKeyData, IAreaKey> _areaKeyFactory;
        private readonly IReader<IAreaKey, IPersistableArea> _areaReader;
        private readonly IDecoratorFactory<OwnedActivityData, IActivity, IOwnedActivity> _ownedActivityFactory;
        private readonly IDecoratorFactory<PersistableActivityData, IOwnedActivity, IPersistableActivity> _persistableActivityFactory;
        private readonly IReader<IPersonKey, IPersistablePerson> _personReader;

        public ActivityCreator(IReader<IPersonKey, IPersistablePerson> personReader,
            IFactory<ActivityData, IActivity> activityFactory,
            IDecoratorFactory<OwnedActivityData, IActivity, IOwnedActivity> ownedActivityFactory,
            IDecoratorFactory<PersistableActivityData, IOwnedActivity, IPersistableActivity> persistableActivityFactory,
            IDecoratorFactory<ActivityAreaData, IActivity, IActivityArea> activityAreaFactory,
            IReader<IAreaKey, IPersistableArea> areaReader,
            IFactory<AreaKeyData, IAreaKey> areaKeyFactory,
            IWriter<IPersistableActivity, IActivityKey> activityWriter)
        {
            _personReader = personReader;
            _activityFactory = activityFactory;
            _ownedActivityFactory = ownedActivityFactory;
            _persistableActivityFactory = persistableActivityFactory;
            _activityAreaFactory = activityAreaFactory;
            _areaReader = areaReader;
            _areaKeyFactory = areaKeyFactory;
            _activityWriter = activityWriter;
        }

        public void Create(Tuple<CreateActivityPageModel, IPersonKey> input)
        {
            var model = input.Item1;
            var personKey = input.Item2;

            var person = _personReader.Read(personKey);

            var activity = _activityFactory.Create(new ActivityData
            {
                Title = model.Name,
                Description = model.Description,
                Created = DateTime.UtcNow
            });

            var areaKey = _areaKeyFactory.Create(new AreaKeyData
            {
                Identifier = model.AreaId
            });

            var area = GetArea(model, areaKey);

            var activityArea = _activityAreaFactory.Create(new ActivityAreaData
            {
                Area = area
            }, activity);

            var ownedActivity = _ownedActivityFactory.Create(new OwnedActivityData
            {
                OwnerKey = personKey
            }, activityArea);

            var persistableArea = _persistableActivityFactory.Create(new PersistableActivityData(), ownedActivity);

            _activityWriter.Save(persistableArea);
        }

        private IPersistableArea GetArea(CreateActivityPageModel model, IAreaKey areaKey)
        {
            var area = _areaReader.Read(areaKey).FirstOrDefault();

            if (area == null)
                throw new InvalidOperationException($"Trying to create an activity for an area that does not exist with areaId {model.AreaId}");
            return area;
        }
    }
}
