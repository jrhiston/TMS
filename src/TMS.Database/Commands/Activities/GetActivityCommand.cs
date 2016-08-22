using System.Linq;
using TMS.Data.Entities.Activities;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Data;
using TMS.Layer.Repositories;
using TMS.ModelLayer.Activities;

namespace TMS.Database.Commands.Activities
{
    public class GetActivityCommand : IQueryCommand<ActivityKey, Activity>
    {
        private readonly IConverter<ActivityEntity, Activity> _entityConverter;
        private readonly IDataContextFactory<ActivityEntity> _contextFactory;

        public GetActivityCommand(IDataContextFactory<ActivityEntity> contextFactory,
            IConverter<ActivityEntity, Activity> entityConverter)
        {
            _contextFactory = contextFactory;
            _entityConverter = entityConverter;
        }

        public Maybe<Activity> ExecuteCommand(ActivityKey data)
        {
            using (var context = _contextFactory.Create())
            {
                return _entityConverter.Convert(context.Entities.Single(item => item.Id == data.Identifier));
            }
        }
    }
}
