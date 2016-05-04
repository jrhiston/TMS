using System.Collections.Generic;
using System.Linq;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.Activities.Decorators;
using TMS.ModelLayerInterface.Areas.Data;
using TMS.ModelLayerInterface.Areas.Decorators;

namespace TMS.ModelLayer.Areas.Decorators
{
    public class PersistableActivitiesArea : DecoratorBase<PersistableActivitiesAreaData, AreaData>, IPersistableActivitiesArea
    {
        private readonly List<IPersistableActivity> _activities;

        public PersistableActivitiesArea(IPersistableArea area, 
            IEnumerable<IPersistableActivity> activities) : base(area)
        {
            _activities = activities.ToList();
        }

        protected override PersistableActivitiesAreaData GetData() => new PersistableActivitiesAreaData
        {
            Activities = _activities
        };
    }
}
