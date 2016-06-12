using System.Collections.Generic;
using TMS.Layer;
using TMS.ModelLayerInterface.Tags;
using TMS.ModelLayerInterface.Tags.Data;
using TMS.ModelLayerInterface.Tags.Decorators;

namespace TMS.RepositoryLayerInterface.CommandObjects.Tags
{
    public interface IListTagsCommand
    {
        IList<Maybe<IPersistableTag>> ExecuteCommand(TagFilterData tagFilter);
    }
}
