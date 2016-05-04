using TMS.Layer.Data;
using TMS.ModelLayerInterface.People;

namespace TMS.LayerInterface.People
{
    public class PersonFilterData : IData
    {
        public IPersonKey PersonKey { get; set; }
        public string UserName { get; set; }
    }
}