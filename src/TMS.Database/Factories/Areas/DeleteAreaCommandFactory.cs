using TMS.Database.Commands.Areas;
using TMS.Database.Entities.Areas;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Areas;

namespace TMS.Database.Factories.Areas
{
    public class DeleteAreaCommandFactory : IQueryFactory<INonQueryCommand<IAreaKey>>
    {
        private readonly IDatabaseContextFactory<AreaEntity> _contextFactory;

        public DeleteAreaCommandFactory(IDatabaseContextFactory<AreaEntity> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public INonQueryCommand<IAreaKey> Create() => new DeleteAreaCommand(_contextFactory);
    }
}
