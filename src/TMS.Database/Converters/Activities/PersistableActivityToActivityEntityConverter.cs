using System;
using TMS.Database.Entities.Activities;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.ModelLayerInterface.Activities.Decorators;

namespace TMS.Database.Converters.Activities
{
    public class PersistableActivityToActivityEntityConverter : IConverter<IPersistableActivity, ActivityEntity>
    {
        public Maybe<ActivityEntity> Convert(IPersistableActivity input)
        {
            var activityEntity = new ActivityEntity();

            activityEntity.Accept(input);

            return new Maybe<ActivityEntity>(activityEntity);
        }
    }
}
