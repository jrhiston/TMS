using TMS.Layer.Factories;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;

namespace TMS.ModelLayer.Activities.Factories
{
    public class ActivityKeyFactory : IFactory<ActivityKeyData, IActivityKey>
    {
        public IActivityKey Create(ActivityKeyData data) => new ActivityKey { Identifier = data.Identifier };
    }
}
