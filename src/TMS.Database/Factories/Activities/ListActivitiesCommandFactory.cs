using System.Collections.Generic;
using TMS.Database.Commands.Activities;
using TMS.Database.Entities.Activities;
using TMS.Layer.Conversion;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Activities.Decorators;

namespace TMS.Database.Factories.Activities
{
    public class ListActivitiesCommandFactory : IQueryFactory<IQueryCommand<ActivityFilterData, IEnumerable<IPersistableActivity>>>
    {
        private readonly IDatabaseContextFactory<ActivityEntity> _contextFactory;
        private readonly IConverter<ActivityEntity, IPersistableActivity> _entityToPersistableActivityConverter;

        public ListActivitiesCommandFactory(IDatabaseContextFactory<ActivityEntity> contextFactory,
            IConverter<ActivityEntity, IPersistableActivity> entityToPersistableActivityConverter)
        {
            _contextFactory = contextFactory;
            _entityToPersistableActivityConverter = entityToPersistableActivityConverter;
        }

        public IQueryCommand<ActivityFilterData, IEnumerable<IPersistableActivity>> Create() => new ListActivitiesCommand(_contextFactory, _entityToPersistableActivityConverter);
    }
}
