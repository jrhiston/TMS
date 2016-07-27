using System;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Activities.Decorators;
using TMS.ModelLayerInterface.Areas;

namespace TMS.ModelLayer.Activities.Decorators
{
    public class ActivityArea : DecoratorBase<ActivityAreaData, ActivityData>, IActivityArea
    {
        private readonly IArea _area;

        public ActivityArea(IActivity activity, ActivityAreaData data) : base(activity)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            _area = data.Area;
        }

        protected override ActivityAreaData GetData() => new ActivityAreaData
        {
            Area = _area
        };
    }
}
