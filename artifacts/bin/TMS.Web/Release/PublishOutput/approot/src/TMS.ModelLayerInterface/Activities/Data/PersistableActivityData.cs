using TMS.Layer.Data;

namespace TMS.ModelLayerInterface.Activities.Data
{
    public class PersistableActivityData : IData
    {
        public IActivityKey Key { get; set; }
    }
}
