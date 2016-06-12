using System.Collections.Generic;
using TMS.Layer.Data;
using TMS.ModelLayerInterface.Activities.Decorators;

namespace TMS.ModelLayerInterface.Areas.Data
{
    public class PersistableActivitiesAreaData : IData
    {
        public IEnumerable<IPersistableActivity> Activities { get; set; }
    }
}
