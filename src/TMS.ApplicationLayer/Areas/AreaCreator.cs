using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Layer.Creators;
using TMS.Layer.Factories;
using TMS.Layer.Persistence;
using TMS.Layer.Readers;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayerInterface.Areas.Decorators;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.People.Decorators;
using TMS.ViewModelLayer.Models.Areas.Pages;

namespace TMS.ApplicationLayer.Areas
{
    public class AreaCreator : ICreator<Tuple<AreaPageModelBase, IPersonKey>>
    {
        private readonly IFactory<AreaData, IArea> _areaFactory;
        private readonly IFactory<AreaKeyData, IAreaKey> _areaKeyFactory;
        private readonly IDecoratorFactory<AreaWithPeopleData, IPersistableArea, IAreaWithPeople> _areaWithPeopleFactory;
        private readonly IWriter<IPersistableArea, IAreaKey> _areaWriter;
        private readonly IDecoratorFactory<PersistableAreaData, IArea, IPersistableArea> _persistableAreaFactory;
        private readonly IReader<IPersonKey, IPersistablePerson> _personReader;

        public AreaCreator(IReader<IPersonKey, IPersistablePerson> personReader,
            IFactory<AreaData, IArea> areaFactory,
            IDecoratorFactory<PersistableAreaData, IArea, IPersistableArea> persistableAreaFactory,
            IWriter<IPersistableArea, IAreaKey> areaWriter,
            IDecoratorFactory<AreaWithPeopleData, IPersistableArea, IAreaWithPeople> areaWithPeopleFactory,
            IFactory<AreaKeyData,IAreaKey> areaKeyFactory)
        {
            _personReader = personReader;
            _areaFactory = areaFactory;
            _persistableAreaFactory = persistableAreaFactory;
            _areaWriter = areaWriter;
            _areaWithPeopleFactory = areaWithPeopleFactory;
            _areaKeyFactory = areaKeyFactory;
        }

        public void Create(Tuple<AreaPageModelBase, IPersonKey> input)
        {
            var model = input.Item1;
            var personKey = input.Item2;

            var person = _personReader.Read(personKey);

            var area = _areaFactory.Create(new AreaData
            {
                Name = model.Name,
                Description = model.Description
            });

            var persistableArea = _persistableAreaFactory.Create(new PersistableAreaData
            {
                AreaKey = _areaKeyFactory.Create(new AreaKeyData { Identifier = model.AreaId })
            }, area);

            var areaWithPeople = _areaWithPeopleFactory.Create(new AreaWithPeopleData
            {
                People = new List<IPersistablePerson> { person.FirstOrDefault() }
            }, persistableArea);

            _areaWriter.Save(areaWithPeople);
        }
    }
}
