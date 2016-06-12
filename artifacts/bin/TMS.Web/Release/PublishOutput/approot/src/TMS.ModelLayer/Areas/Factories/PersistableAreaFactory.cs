using TMS.Layer.Factories;
using TMS.ModelLayer.Areas.Decorators;
using TMS.ModelLayer.TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayerInterface.Areas.Decorators;

namespace TMS.ModelLayer.Areas.Factories
{
    public class PersistableAreaFactory : IDecoratorFactory<PersistableAreaData, IArea, IPersistableArea>
    {
        public IPersistableArea Create(PersistableAreaData data, IArea decoratee) => new PersistableArea(decoratee, data);
    }
}
