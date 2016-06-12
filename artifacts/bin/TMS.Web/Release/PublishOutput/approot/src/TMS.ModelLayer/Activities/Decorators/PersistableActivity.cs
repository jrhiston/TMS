using System;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.Activities;
using TMS.ModelLayerInterface.Activities.Data;
using TMS.ModelLayerInterface.Activities.Decorators;

namespace TMS.ModelLayer.Activities.Decorators
{
    public class PersistableActivity : DecoratorBase<PersistableActivityData, ActivityData>, IPersistableActivity
    {
        private IActivityKey _key;

        public PersistableActivity(IOwnedActivity ownedActivity,
            PersistableActivityData data) : base(ownedActivity)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            
            _key = data.Key;
        }
        
        protected override PersistableActivityData GetData() => new PersistableActivityData
        {
            Key = _key
        };
    }
}
