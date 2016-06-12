using TMS.Layer.Factories;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;

namespace TMS.ModelLayer.Activities.Factories
{
    public class ActivityFactory : IFactory<ActivityData, IActivity>
    {
        public IActivity Create(ActivityData data) => new Activity(data.Title, data.Description, data.CreationDate);
    }
}
