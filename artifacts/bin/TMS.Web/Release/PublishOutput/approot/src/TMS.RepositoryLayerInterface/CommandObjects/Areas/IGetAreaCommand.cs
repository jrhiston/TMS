using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.Areas.Decorators;

namespace TMS.RepositoryLayerInterface.CommandObjects.Areas
{
    public interface IGetAreaCommand : IQueryCommand<IAreaKey, IPersistableArea>
    {
    }
}