using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Decorators;

namespace TMS.RepositoryLayerInterface.CommandObjects.Activities
{
    public interface ISaveActivityCommand
    {
        IActivityKey ExecuteCommand(IPersistableActivity activityData);
    }
}
