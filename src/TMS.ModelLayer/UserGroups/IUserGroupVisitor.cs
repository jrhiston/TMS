namespace TMS.ModelLayer.UserGroups
{
    public interface IUserGroupVisitor
    {
        IUserGroupVisitor Visit(UserGroupKey userGroupKey);
    }
}