using System;
using TMS.Layer.Data;

namespace TMS.ModelLayerInterface.UserGroups.Data
{
    public class UserGroupData : IData
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created { get; set; }
    }
}
