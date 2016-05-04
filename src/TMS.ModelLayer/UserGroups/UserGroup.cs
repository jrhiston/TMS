using System;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.UserGroups;
using TMS.ModelLayerInterface.UserGroups.Data;

namespace TMS.ModelLayer.UserGroups
{
    public class UserGroup : ModelObjectBase<UserGroupData>, IUserGroup
    {
        private string _name;
        private string _description;
        private DateTime _created;

        public UserGroup(UserGroupData userGroupData)
        {
            if (userGroupData == null)
                throw new ArgumentNullException(nameof(userGroupData));

            _name = userGroupData.Name;
            _description = userGroupData.Description;
            _created = userGroupData.Created;
        }

        protected override UserGroupData GetData() => new UserGroupData
        {
            Name = _name,
            Description = _description,
            Created = _created
        };
    }
}
