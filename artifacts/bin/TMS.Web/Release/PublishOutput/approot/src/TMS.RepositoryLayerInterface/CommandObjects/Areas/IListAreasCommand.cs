using System.Collections.Generic;
using TMS.Layer.Data;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Areas.Decorators;

namespace TMS.RepositoryLayerInterface.CommandObjects.Areas
{
    public interface IListAreasCommand : IQueryCommand<IData, IEnumerable<IPersistableArea>>
    {
    }
}