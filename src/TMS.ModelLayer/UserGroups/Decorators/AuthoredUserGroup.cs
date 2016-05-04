using System;
using TMS.Layer.ModelObjects;
using TMS.ModelLayerInterface.People;
using TMS.ModelLayerInterface.UserGroups;
using TMS.ModelLayerInterface.UserGroups.Data;
using TMS.ModelLayerInterface.UserGroups.Decorators;

namespace TMS.ModelLayer.UserGroups.Decorators
{
    public class AuthoredUserGroup : DecoratorBase<AuthoredUserGroupData, UserGroupData>, IAuthoredUserGroup
    {
        private readonly IPersonKey _authorKey;

        public AuthoredUserGroup(IUserGroup userGroup, AuthoredUserGroupData data) : base(userGroup)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            
            _authorKey = data.AuthorKey;
        }

        protected override AuthoredUserGroupData GetData() => new AuthoredUserGroupData
        {
            AuthorKey = _authorKey
        };
    }
}
