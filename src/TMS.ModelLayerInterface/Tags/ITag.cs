using TMS.Layer.ModelObjects;
using TMS.Layer.Visitors;
using TMS.ModelLayerInterface.Tags.Data;

namespace TMS.ModelLayerInterface.Tags
{
    /// <summary>
    /// Represents a tag that can be assigned to an activity, or other child tags.
    /// </summary>
    public interface ITag : IModelObject<IVisitor<TagData>, TagData>
    {
    }
}
