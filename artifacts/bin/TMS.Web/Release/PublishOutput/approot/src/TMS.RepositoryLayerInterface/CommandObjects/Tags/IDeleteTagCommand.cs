
using TMS.ModelLayerInterface.Tags;

namespace TMS.RepositoryLayerInterface.CommandObjects.Tags
{
    public interface IDeleteTagCommand
    {
        void ExecuteCommand(ITagKey key);
    }
}
