using TMS.Layer.Data;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.UserGroups;

namespace TMS.ModelLayerInterface.Areas.Data
{
    public class AreaFilterData : IData
    {
        public IAreaKey AreaKey { get; set; }
        public IPersonKey PersonKey { get; set; }
        public IUserGroupKey UserGroupKey { get; set; }
    }
}
