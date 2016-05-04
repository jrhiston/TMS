using TMS.Layer;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Decorators;

namespace TMS.RepositoryLayerInterface.CommandObjects.Activities
{
    public interface IGetActivityCommand
    {
        Maybe<IPersistableActivity> ExecuteCommand(IActivityKey activityKey);
    }
}
