using TMS.Layer.ModelObjects;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.UserGroups.Data;

namespace TMS.ModelLayerInterface.UserGroups
{
    public interface IUserGroup : IModelObject<IVisitor<UserGroupData>, UserGroupData>
    {
    }
}