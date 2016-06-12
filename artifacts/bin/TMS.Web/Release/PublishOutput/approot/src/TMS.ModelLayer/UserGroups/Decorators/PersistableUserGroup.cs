using System;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.UserGroups;
using TMS.ModelLayerInterface.UserGroups.Data;
using TMS.ModelLayerInterface.UserGroups.Decorators;

namespace TMS.ModelLayer.UserGroups.Decorators
{
    public class PersistableUserGroup : DecoratorBase<PersistableUserGroupData, UserGroupData>, IPersistableUserGroup
    {
        private readonly IUserGroupKey _userGroupKey;

        public PersistableUserGroup(IAuthoredUserGroup userGroup,
            PersistableUserGroupData data) : base(userGroup)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            
            _userGroupKey = data.UserGroupKey;
        }

        protected override PersistableUserGroupData GetData() => new PersistableUserGroupData
        {
            UserGroupKey = _userGroupKey
        };
    }
}
