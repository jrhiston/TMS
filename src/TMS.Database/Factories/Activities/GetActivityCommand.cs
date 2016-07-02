using TMS.Database.Commands.Activities;
using TMS.Database.Entities.Activities;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Decorators;

namespace TMS.Database.Factories.Activities
{
    public class GetActivityCommandFactory : IQueryFactory<IQueryCommand<IActivityKey, IActivity>>
    {
        private readonly IConverter<ActivityEntity, IActivity> _entityConverter;
        private readonly IDatabaseContextFactory<ActivityEntity> _contextFactory;

        public GetActivityCommandFactory(IDatabaseContextFactory<ActivityEntity> contextFactory,
            IConverter<ActivityEntity, IActivity> entityConverter)
        {
            _contextFactory = contextFactory;
            _entityConverter = entityConverter;
        }

        public IQueryCommand<IActivityKey, IActivity> Create() => new GetActivityCommand(_contextFactory, _entityConverter);
    }
}
