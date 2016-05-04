using System.Collections.Generic;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Tags;

namespace TMS.RepositoryLayerInterface.CommandObjects.Activities.Tags
{
    public interface ISaveActivityTagsCommand
    {
        void ExecuteCommand(IActivityKey activityKey, IEnumerable<ITagKey> tagKeys);
    }
}