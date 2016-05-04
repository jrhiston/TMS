using System;
using TMS.Layer;
using TMS.Layer.Data;
using TMS.Layer.Visitors;

namespace TMS.Layer.ModelObjects
{
    public abstract class ModelObjectBase<TData> : ModelObjectData<TData>, IModelObject<IVisitor<TData>, TData>
        where TData : IData
    {
        public void Accept(Func<IVisitor<TData>> visitorFactory)
        {
            var visitor = visitorFactory();

            visitor.Visit(GetData());
        }
    }
}
