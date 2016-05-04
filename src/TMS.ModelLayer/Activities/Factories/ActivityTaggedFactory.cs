using TMS.Layer.Factories;
using TMS.ModelLayer.Activities.Decorators;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Activities.Decorators;

namespace TMS.ModelLayer.Activities.Factories
{
    public class ActivityTaggedFactory : IDecoratorFactory<TaggableActivityData, IPersistableActivity, ITaggableActivity>
    {
        public ITaggableActivity Create(TaggableActivityData data, IPersistableActivity decoratee) => new TaggableActivity(decoratee, data);
    }
}
