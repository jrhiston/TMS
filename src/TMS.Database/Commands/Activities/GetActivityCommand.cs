using System.Linq;
using TMS.Database.Entities.Activities;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Repositories;
using TMS.ModelLayerInterface.Activities;

namespace TMS.Database.Commands.Activities
{
    public class GetActivityCommand : IQueryCommand<IActivityKey, IActivity>
    {
        private readonly IConverter<ActivityEntity, IActivity> _entityConverter;
        private readonly IDatabaseContextFactory<ActivityEntity> _contextFactory;

        public GetActivityCommand(IDatabaseContextFactory<ActivityEntity> contextFactory,
            IConverter<ActivityEntity, IActivity> entityConverter)
        {
            _contextFactory = contextFactory;
            _entityConverter = entityConverter;
        }

        public Maybe<IActivity> ExecuteCommand(IActivityKey data)
        {
            using (var context = _contextFactory.Create())
            {
                return _entityConverter.Convert(context.Entities.Single(item => item.Id == data.Identifier));
            }
        }
    }
}
