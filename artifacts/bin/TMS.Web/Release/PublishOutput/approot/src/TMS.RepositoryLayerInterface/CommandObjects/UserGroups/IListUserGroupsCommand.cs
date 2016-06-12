using System.Collections.Generic;
using TMS.ModelLayerInterface.UserGroups;
using TMS.ModelLayerInterface.UserGroups.Data;

namespace TMS.RepositoryLayerInterface.CommandObjects.UserGroups
{
    public interface IListUserGroupsCommand
    {
        IList<IUserGroup> ExecuteCommand(UserGroupFilterData userGroupFilterData);
    }
}