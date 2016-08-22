using System.Collections.Generic;
using System.Linq;
using TMS.Data.Entities.Activities;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Data;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Activities;

namespace TMS.Database.Commands.Activities
{
    public class ListActivitiesCommand : IQueryCommand<ActivityFilterData, IEnumerable<Activity>>
    {
        private readonly IDataContextFactory<ActivityEntity> _contextFactory;
        private readonly IConverter<ActivityEntity, Activity> _converter;

        public ListActivitiesCommand(IDataContextFactory<ActivityEntity> contextFactory,
            IConverter<ActivityEntity, Activity> converter)
        {
            _contextFactory = contextFactory;
            _converter = converter;
        }

        public Maybe<IEnumerable<Activity>> ExecuteCommand(ActivityFilterData data)
        {
            using (var context = _contextFactory.Create())
            {
                if (data == null)
                    return new Maybe<IEnumerable<Activity>>();

                var areas = context.Entities.Where(item => item.AreaId == data.AreaKey.Identifier);

                return new Maybe<IEnumerable<Activity>>(areas
                    .Select(area => _converter.Convert(area))
                    .SelectMany(item => item)
                    .ToList());
            }
        }
    }
}
