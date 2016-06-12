using System.Collections.Generic;
using TMS.ModelLayerInterface.Tags;

namespace TMS.RepositoryLayerInterface.CommandObjects.Tags
{
    public interface ISaveTagsOnTagCommand
    {
        void ExecuteCommand(ITagKey childTagKey, IEnumerable<ITagKey> parentTagKeys);
    }
}