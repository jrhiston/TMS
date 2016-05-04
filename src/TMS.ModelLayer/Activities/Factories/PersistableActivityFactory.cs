using TMS.Layer.Factories;
using TMS.ModelLayer.Activities.Decorators;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Activities.Decorators;

namespace TMS.ModelLayer.Activities
{
    public class PersistableActivityFactory : IDecoratorFactory<PersistableActivityData, IOwnedActivity, IPersistableActivity>
    {
        public IPersistableActivity Create(PersistableActivityData data, IOwnedActivity decoratee) => new PersistableActivity(decoratee, data);
    }
}
