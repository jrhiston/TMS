
using TMS.ModelLayerInterface.Tags;

namespace TMS.RepositoryLayerInterface.CommandObjects.Tags
{
    public interface IDeleteParentTagFromTagCommand
    {
        void ExecuteCommand(ITagKey tagKey, ITagKey parentTagKey);
    }
}