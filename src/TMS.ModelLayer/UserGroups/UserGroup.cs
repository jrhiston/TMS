using TMS.Layer.ModelObjects;

namespace TMS.ModelLayer.UserGroups
{
    public class UserGroup : AggregateRoot<IUserGroupElement, IUserGroupVisitor>, IUserGroupElement
    {
        public UserGroup(params IUserGroupElement[] elements) : base(elements)
        {
        }
    }
}
