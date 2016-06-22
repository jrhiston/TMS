using TMS.Layer.Factories;
using TMS.ModelLayer.Areas.Decorators;
using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayerInterface.Areas.Decorators;

namespace TMS.ModelLayer.Areas.Factories
{
    public class AreaWithPeopleFactory : IDecoratorFactory<AreaWithPeopleData, IPersistableArea, IAreaWithPeople>
    {
        public IAreaWithPeople Create(AreaWithPeopleData data, IPersistableArea decoratee) => new AreaWithPeople(decoratee, data);
    }
}
