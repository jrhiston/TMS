using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Tags;

namespace TMS.RepositoryLayerInterface.CommandObjects.Activities.Tags
{
    public interface IActivityTagLinkExistsCommand
    {
        bool ExecuteCommand(IActivityKey activityKey, ITag tag);
    }
}