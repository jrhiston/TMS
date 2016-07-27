using System.Collections.Generic;
using System.Linq;
using TMS.Database.Entities.Activities;
using TMS.Database.Entities.Areas;
using TMS.Database.Entities.People;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Activities.Decorators;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayerInterface.Areas.Decorators;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Data;
using TMS.ModelLayerInterface.People.Decorators;

namespace TMS.Database.Converters.Areas
{
    public class AreaEntityToAreaConverter : IConverter<AreaEntity, IArea>
    {
        private readonly IConverter<ActivityEntity, IPersistableActivity> _activityEntityToPersistableActivityConverter;
        private readonly IFactory<AreaData, IArea> _areaFactory;
        private readonly IFactory<AreaKeyData, IAreaKey> _areaKeyFactory;
        private readonly IDecoratorFactory<AreaWithPeopleData, IPersistableArea, IAreaWithPeople> _areaWithPeopleFactory;
        private readonly IQueryCommand<IPersonKey, IPersistablePerson> _getPersonCommand;
        private readonly IDecoratorFactory<PersistableActivitiesAreaData, IPersistableArea, IPersistableActivitiesArea> _persistableActivitiesAreaFactory;
        private readonly IDecoratorFactory<PersistableAreaData, IArea, IPersistableArea> _persistableAreaFactory;
        private readonly IConverter<PersonEntity, IPersistablePerson> _persistablePersonConverter;
        private readonly IFactory<PersonKeyData, IPersonKey> _personKeyFactory;

        public AreaEntityToAreaConverter(IFactory<AreaKeyData, IAreaKey> areaKeyFactory,
            IFactory<AreaData, IArea> areaFactory,
            IDecoratorFactory<PersistableAreaData, IArea, IPersistableArea> persistableAreaFactory,
            IDecoratorFactory<PersistableActivitiesAreaData, IPersistableArea, IPersistableActivitiesArea> persistableActivitiesAreaFactory,
            IDecoratorFactory<AreaWithPeopleData, IPersistableArea, IAreaWithPeople> areaWithPeopleFactory,
            IConverter<ActivityEntity, IPersistableActivity> activityEntityToPersistableActivityConverter,
            IConverter<PersonEntity, IPersistablePerson> persistablePersonConverter,
            IQueryCommand<IPersonKey, IPersistablePerson> getPersonCommand,
            IFactory<PersonKeyData, IPersonKey> personKeyFactory)
        {
            _areaKeyFactory = areaKeyFactory;
            _areaFactory = areaFactory;
            _persistableAreaFactory = persistableAreaFactory;
            _persistableActivitiesAreaFactory = persistableActivitiesAreaFactory;
            _activityEntityToPersistableActivityConverter = activityEntityToPersistableActivityConverter;
            _areaWithPeopleFactory = areaWithPeopleFactory;
            _persistablePersonConverter = persistablePersonConverter;
            _getPersonCommand = getPersonCommand;
            _personKeyFactory = personKeyFactory;
        }

        public Maybe<IArea> Convert(AreaEntity input)
        {
            var areaKey = _areaKeyFactory.Create(new AreaKeyData
            {
                Identifier = input.Id
            });

            var area = _areaFactory.Create(new AreaData
            {
                Name = input.Name,
                Description = input.Description,
                Created = input.Created
            });

            var persistableArea = _persistableAreaFactory.Create(new PersistableAreaData
            {
                AreaKey = areaKey
            }, area);

            var areaWithActivities = _persistableActivitiesAreaFactory.Create(new PersistableActivitiesAreaData
            {
                Activities = input.Activities?
                    .Select(_activityEntityToPersistableActivityConverter.Convert)
                    .SelectMany(item => item)
                    .ToList() ?? new List<IPersistableActivity>()
            }, persistableArea);

            var listOfPeople = GetListOfPeople(input);

            var areaWithPeople = _areaWithPeopleFactory.Create(new AreaWithPeopleData
            {
                People = listOfPeople
            }, areaWithActivities);

            return new Maybe<IArea>(areaWithPeople);
        }

        private List<IPersistablePerson> GetListOfPeople(AreaEntity input)
        {
            var listOfPeople = new List<IPersistablePerson>();
            foreach (var personKey in input.AreaPersons?.Select(item => item.PersonId))
            {
                if (personKey > 0)
                {
                    var matchingPerson = _getPersonCommand.ExecuteCommand(_personKeyFactory.Create(new PersonKeyData { Identifier = personKey }));

                    var person = matchingPerson.FirstOrDefault();

                    if (person != null)
                        listOfPeople.Add(person);
                }
            }

            return listOfPeople;
        }
    }
}
