using TMS.Layer.Data;
using TMS.ModelLayerInterface.People;

namespace TMS.ModelLayerInterface.UserGroups.Data
{
    public class AuthoredUserGroupData : IData
    {
        public IPersonKey AuthorKey { get; set; }
    }
}
