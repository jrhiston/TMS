using System;

namespace TMS.ModelLayer.UserGroups
{
    public class UserGroupKey : Key, IUserGroupElement
    {
        public UserGroupKey(long id) : base(id)
        {
        }

        public IUserGroupVisitor Accept(IUserGroupVisitor visitor) => visitor.Visit(this);
    }
}
