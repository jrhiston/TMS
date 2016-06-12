using System;
using TMS.Layer.Data;
using TMS.ModelLayerInterface.Areas;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.UserGroups;

namespace TMS.ModelLayerInterface.Activities.Data
{
    public class ActivityFilterData : IData
    {
        public IPersonKey PersonKey { get; set; }
        public IUserGroupKey UserGroupKey { get; set; }
        public DateTime? StartCreationDate { get; set; }
        public DateTime? EndCreationDate { get; set; }
        public IAreaKey AreaKey { get; set; }
    }
}
