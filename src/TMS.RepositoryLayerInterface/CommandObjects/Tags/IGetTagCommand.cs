
using TMS.ModelLayerInterface.Tags;
using TMS.ModelLayerInterface.Tags.Decorators;

namespace TMS.RepositoryLayerInterface.CommandObjects.Tags
{
    public interface IGetTagCommand
    {
        IPersistableTag ExecuteCommand(ITagKey tagKey);
    }
}
