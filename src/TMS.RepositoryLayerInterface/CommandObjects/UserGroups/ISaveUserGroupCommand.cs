using TMS.ModelLayerInterface.UserGroups;

namespace TMS.RepositoryLayerInterface.CommandObjects.UserGroups
{
    public interface ISaveUserGroupCommand
    {
        IUserGroupKey ExecuteCommand(IUserGroup userGroup);
    }
}