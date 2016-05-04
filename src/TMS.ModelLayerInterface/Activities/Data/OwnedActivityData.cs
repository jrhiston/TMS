using TMS.Layer.Data;
using TMS.ModelLayerInterface.People;

namespace TMS.ModelLayerInterface.Activities.Data
{
    public class OwnedActivityData : IData
    {
        public IPersonKey OwnerKey { get; set; }
    }
}
