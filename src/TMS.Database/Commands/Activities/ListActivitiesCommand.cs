using System;
using System.Collections.Generic;
using System.Linq;
using TMS.Database.Entities.Activities;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Activities.Decorators;
using TMS.ModelLayerInterface.Areas;

namespace TMS.Database.Commands.Activities
{
    public class ListActivitiesCommand : IQueryCommand<ActivityFilterData, IEnumerable<IPersistableActivity>>
    {
        private readonly IDatabaseContext<ActivityEntity> _activitiesContext;
        private readonly IConverter<ActivityEntity, IPersistableActivity> _entityToPersistableActivityConverter;

        public ListActivitiesCommand(IDatabaseContext<ActivityEntity> activitiesContext,
            IConverter<ActivityEntity,IPersistableActivity> entityToPersistableActivityConverter)
        {
            _activitiesContext = activitiesContext;
            _entityToPersistableActivityConverter = entityToPersistableActivityConverter;
        }

        public Maybe<IEnumerable<IPersistableActivity>> ExecuteCommand(ActivityFilterData data)
        {
            if (data == null)
                return new Maybe<IEnumerable<IPersistableActivity>>();

            var areas = _activitiesContext.Entities.Where(item => item.AreaId == data.AreaKey.Identifier);

            return new Maybe<IEnumerable<IPersistableActivity>>(areas
                .Select(area => _entityToPersistableActivityConverter.Convert(area))
                .SelectMany(item => item)
                .ToList());
        }
    }
}
