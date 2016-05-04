using System;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Activities.Decorators;
using TMS.ModelLayerInterface.People;

namespace TMS.ModelLayer.Activities.Decorators
{
    public class OwnedActivity : DecoratorBase<OwnedActivityData, ActivityData>, IOwnedActivity
    {
        private readonly IPersonKey _personKey;

        public OwnedActivity(IActivity activity, OwnedActivityData data) : base(activity)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            
            _personKey = data.OwnerKey;
        }

        protected override OwnedActivityData GetData() =>new OwnedActivityData
        {
            OwnerKey = _personKey
        };
    }
}
