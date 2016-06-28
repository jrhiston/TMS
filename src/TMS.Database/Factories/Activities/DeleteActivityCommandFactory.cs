using TMS.Database.Commands.Activities;
using TMS.Database.Entities.Activities;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Activities;

namespace TMS.Database.Factories.Activities
{
    public class DeleteActivityCommandFactory : IQueryFactory<INonQueryCommand<IActivityKey>>
    {
        private readonly IDatabaseContextFactory<ActivityEntity> _contextFactory;

        public DeleteActivityCommandFactory(IDatabaseContextFactory<ActivityEntity> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public INonQueryCommand<IActivityKey> Create() => new DeleteActivityCommand(_contextFactory);
    }
}
