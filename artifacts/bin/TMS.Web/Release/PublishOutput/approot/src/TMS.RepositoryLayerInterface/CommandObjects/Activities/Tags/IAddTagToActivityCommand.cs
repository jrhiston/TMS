using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Tags;

namespace TMS.RepositoryLayerInterface.CommandObjects.Activities.Tags
{
    public interface IAddTagToActivityCommand
    {
        void ExecuteCommand(ITag tag, IActivityKey activityKey);
    }
}