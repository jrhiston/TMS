using System.Collections.Generic;
using TMS.ModelLayerInterface.Tags;

namespace TMS.RepositoryLayerInterface.CommandObjects.Tags
{
    public interface ISaveTagsCommand
    {
        List<ITagKey> ExecuteCommand(IEnumerable<ITag> tags);
    }
}