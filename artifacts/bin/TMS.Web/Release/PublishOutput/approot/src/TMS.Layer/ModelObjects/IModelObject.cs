using TMS.Layer.Data;
using TMS.Layer.Visitors;

namespace TMS.Layer.ModelObjects
{
    /// <summary>
    /// Represents a model object. 
    /// 
    /// Every model object should have the ability to be visited to obtain it's data.
    /// </summary>
    public interface IModelObject<TVisitor, TData> : IVisited<TVisitor, TData>
        where TVisitor : IVisitor<TData>
        where TData : IData
    {
    }
}
