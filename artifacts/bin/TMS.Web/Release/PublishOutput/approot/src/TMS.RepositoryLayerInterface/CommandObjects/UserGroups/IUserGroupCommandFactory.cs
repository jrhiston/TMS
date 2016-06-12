namespace TMS.RepositoryLayerInterface.CommandObjects.UserGroups
{
    public interface IUserGroupCommandFactory
    {
        IDeleteUserGroupCommand CreateDeleteUserGroupCommand();
        ISaveUserGroupCommand CreateSaveUserGroupCommand();
        IListUserGroupsCommand CreateListUserGroupsCommand();
        IGetUserGroupCommand CreateGetUserGroupCommand();
    }
}