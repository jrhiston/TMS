using System;
using System.Collections.Generic;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayerInterface.Areas.Decorators;
using TMS.ModelLayerInterface.People.Decorators;

namespace TMS.ModelLayer.Areas.Decorators
{
    public class AreaWithPeople : DecoratorBase<AreaWithPeopleData, AreaData>, IAreaWithPeople
    {
        private readonly List<IPersistablePerson> _people;

        public AreaWithPeople(IPersistableArea decoratee, AreaWithPeopleData data) : base(decoratee)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            _people = data.People;
        }

        protected override AreaWithPeopleData GetData() => new AreaWithPeopleData
        {
            People = _people
        };
    }
}
