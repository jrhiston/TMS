using TMS.Layer.Factories;
using TMS.ModelLayer.Areas.Decorators;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayerInterface.Areas.Decorators;

namespace TMS.ModelLayer.Areas.Factories
{
    public class PersistableActivitiesAreaFactory : IDecoratorFactory<PersistableActivitiesAreaData, IPersistableArea, IPersistableActivitiesArea>
    {
        public IPersistableActivitiesArea Create(PersistableActivitiesAreaData data, IPersistableArea decoratee) => new PersistableActivitiesArea(decoratee, data.Activities);
    }
}
