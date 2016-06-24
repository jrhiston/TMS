using TMS.Layer.Factories;
using TMS.ModelLayer.Activities.Decorators;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Activities.Decorators;

namespace TMS.ModelLayer.Activities.Factories
{
    public class ActivityAreaFactory : IDecoratorFactory<ActivityAreaData, IActivity, IActivityArea>
    {
        public IActivityArea Create(ActivityAreaData data, IActivity decoratee) => new ActivityArea(decoratee, data);
    }
}
