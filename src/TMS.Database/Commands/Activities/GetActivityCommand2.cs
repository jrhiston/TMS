using System.Linq;
using TMS.Database.Entities.Activities;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.ModelLayerInterface.Activities;

namespace TMS.Database.Commands.Activities
{
    public class GetActivityCommand2
    {
        private readonly IConverter<ActivityEntity, IActivity> _entityConverter;
        private readonly IDatabaseContextFactory<ActivityEntity> _contextFactory;

        public GetActivityCommand2(IDatabaseContextFactory<ActivityEntity> contextFactory,
            IConverter<ActivityEntity, IActivity> entityConverter)
        {
            _contextFactory = contextFactory;
            _entityConverter = entityConverter;
        }

        public Maybe<IActivity> ExecuteCommand(IActivityKey data, IObjectComposer<IActivity> composer)
        {
            using (var context = _contextFactory.Create())
            {
                var entity = context.Entities.Single(item => item.Id == data.Identifier);

                var initialResult = _entityConverter.Convert(context.Entities.Single(item => item.Id == data.Identifier));

                return composer.GetResult(entity, initialResult);
            }
        }
    }
}
