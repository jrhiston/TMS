using TMS.Database.Commands.Activities;
using TMS.Database.Entities.Activities;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Activities;

namespace TMS.Database.Factories.Activities
{
    public class DeleteActivityCommandFactory : IQueryFactory<INonQueryCommand<IActivityKey>>
    {
        private readonly IDatabaseContext<ActivityEntity> _activitiesContext;

        public DeleteActivityCommandFactory(IDatabaseContext<ActivityEntity> activitiesContext)
        {
            _activitiesContext = activitiesContext;
        }

        public INonQueryCommand<IActivityKey> Create() => new DeleteActivityCommand(_activitiesContext);
    }
}
