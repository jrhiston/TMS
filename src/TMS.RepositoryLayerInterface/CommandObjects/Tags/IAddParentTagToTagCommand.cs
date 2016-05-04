using TMS.ModelLayerInterface.Tags;

namespace TMS.RepositoryLayerInterface.CommandObjects.Tags
{
    public interface IAddParentTagToTagCommand
    {
        void ExecuteCommand(ITagKey tagKey, ITagKey parentTagKey);
    }
}