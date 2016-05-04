using TMS.Layer.ModelObjects;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.Activities.Data;

namespace TMS.ModelLayerInterface.Activities
{
    public interface IActivity : IModelObject<IVisitor<ActivityData>, ActivityData>
    {
    }
}
