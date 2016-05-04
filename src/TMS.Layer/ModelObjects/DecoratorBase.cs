using System;
using TMS.Layer.Data;
using TMS.Layer.Visitors;

namespace TMS.Layer.ModelObjects
{
    public abstract class DecoratorBase<TData, TDecoratedData> : ModelObjectData<TData>, IModelObject<IVisitor<TDecoratedData>, TDecoratedData>
        where TData : IData
        where TDecoratedData : IData
    {
        protected readonly IModelObject<IVisitor<TDecoratedData>, TDecoratedData> _decoratee;

        protected DecoratorBase(IModelObject<IVisitor<TDecoratedData>, TDecoratedData> decoratee)
        {
            _decoratee = decoratee;
        }

        public void Accept(Func<IVisitor<TDecoratedData>> visitorFactory)
        {
            var visitor = visitorFactory();

            var visitorAsDecoratorType = visitor as IVisitor<TData>;
            visitorAsDecoratorType?.Visit(GetData());

            _decoratee.Accept(() => visitor);
        }
    }
}
