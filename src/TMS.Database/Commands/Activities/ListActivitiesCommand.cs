using System.Collections.Generic;
using System.Linq;
using TMS.Database.Entities.Activities;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Activities.Decorators;

namespace TMS.Database.Commands.Activities
{
    public class ListActivitiesCommand : IQueryCommand<ActivityFilterData, IEnumerable<IPersistableActivity>>
    {
        private readonly IDatabaseContextFactory<ActivityEntity> _contextFactory;
        private readonly IConverter<ActivityEntity, IPersistableActivity> _entityToPersistableActivityConverter;

        public ListActivitiesCommand(IDatabaseContextFactory<ActivityEntity> contextFactory,
            IConverter<ActivityEntity, IPersistableActivity> entityToPersistableActivityConverter)
        {
            _contextFactory = contextFactory;
            _entityToPersistableActivityConverter = entityToPersistableActivityConverter;
        }

        public Maybe<IEnumerable<IPersistableActivity>> ExecuteCommand(ActivityFilterData data)
        {
            using (var context = _contextFactory.Create())
            {
                if (data == null)
                    return new Maybe<IEnumerable<IPersistableActivity>>();

                var areas = context.Entities.Where(item => item.AreaId == data.AreaKey.Identifier);

                return new Maybe<IEnumerable<IPersistableActivity>>(areas
                    .Select(area => _entityToPersistableActivityConverter.Convert(area))
                    .SelectMany(item => item)
                    .ToList());
            }
        }
    }
}
