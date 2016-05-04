using TMS.Layer.Data;

namespace TMS.ModelLayerInterface.UserGroups.Data
{
    public class PersistableUserGroupData : IData
    {
        public IUserGroupKey UserGroupKey { get; set; }
    }
}
