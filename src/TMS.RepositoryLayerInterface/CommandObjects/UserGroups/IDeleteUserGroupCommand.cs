using TMS.ModelLayerInterface.UserGroups;

namespace TMS.RepositoryLayerInterface.CommandObjects.UserGroups
{
    public interface IDeleteUserGroupCommand
    {
        void ExecuteCommand(IUserGroupKey userGroupKey);
    }
}