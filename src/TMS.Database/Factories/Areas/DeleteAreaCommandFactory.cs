using TMS.Database.Commands.Areas;
using TMS.Database.Entities.Areas;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Areas;

namespace TMS.Database.Factories.Areas
{
    public class DeleteAreaCommandFactory : IQueryFactory<INonQueryCommand<IAreaKey>>
    {
        private readonly IDatabaseContext<AreaEntity> _areasContext;

        public DeleteAreaCommandFactory(IDatabaseContext<AreaEntity> areasContext)
        {
            _areasContext = areasContext;
        }

        public INonQueryCommand<IAreaKey> Create() => new DeleteAreaCommand(_areasContext);
    }
}
