using TMS.Layer.ModelObjects;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.Areas.Data;

namespace TMS.ModelLayer.TMS.ModelLayerInterface.Areas
{
    public interface IArea : IModelObject<IVisitor<AreaData>, AreaData>
    {
    }
}