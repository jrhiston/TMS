using TMS.ModelLayerInterface.Tags;

namespace TMS.RepositoryLayerInterface.CommandObjects.Tags
{
    public interface ITagLinkExistsCommand
    {
        bool ExecuteCommand(ITagKey childTagKey, ITagKey parentTagKey);
    }
}