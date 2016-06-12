using System.Collections.Generic;
using TMS.Layer.Data;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Areas.Decorators;

namespace TMS.RepositoryLayerInterface.CommandObjects.Areas.Factories
{
    public interface IListAreasCommandFactory : IQueryFactory<IQueryCommand<IData, IEnumerable<IPersistableArea>>>
    {
    }
}
