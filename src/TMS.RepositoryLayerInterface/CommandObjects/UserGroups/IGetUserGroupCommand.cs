using TMS.ModelLayerInterface.UserGroups;
using TMS.ModelLayerInterface.UserGroups.Decorators;

namespace TMS.RepositoryLayerInterface.CommandObjects.UserGroups
{
    public interface IGetUserGroupCommand
    {
        IPersistableUserGroup ExecuteCommand(IUserGroupKey userGroup);
    }
}