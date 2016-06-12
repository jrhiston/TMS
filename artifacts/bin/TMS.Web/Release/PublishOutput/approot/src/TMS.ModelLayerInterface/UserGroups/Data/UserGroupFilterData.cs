using TMS.ModelLayerInterface.People;

namespace TMS.ModelLayerInterface.UserGroups.Data
{
    public class UserGroupFilterData
    {
        public string UserGroupName { get; set; }
        public IPersonKey OwnerKey { get; set; }
    }
}
