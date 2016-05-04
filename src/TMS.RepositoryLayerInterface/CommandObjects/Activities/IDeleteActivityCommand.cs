using TMS.ModelLayerInterface.Activities;

namespace TMS.RepositoryLayerInterface.CommandObjects.Activities
{
    public interface IDeleteActivityCommand
    {
        void ExecuteCommand(IActivityKey key);
    }
}
