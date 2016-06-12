using TMS.Layer.Factories;
using TMS.ModelLayer.Activities.Decorators;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Activities.Decorators;

namespace TMS.ModelLayer.Activities.Factories
{
    public class OwnedActivityFactory : IDecoratorFactory<OwnedActivityData, IActivity, IOwnedActivity>
    {
        public IOwnedActivity Create(OwnedActivityData data, IActivity decoratee) => new OwnedActivity(decoratee, data);
    }
}
