using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TMS.Layer.ModelObjects
{
    public abstract class AggregateRoot<TElement, TVisitor> : IEnumerable<TElement> where TElement : IElement<TVisitor>
    {
        private readonly IEnumerable<TElement> _elements;

        protected AggregateRoot(TElement[] elements)
        {
            _elements = elements;
        }

        public virtual TVisitor Accept(TVisitor visitorFactory)
        {
            return _elements.Aggregate(visitorFactory, (v, e) => e.Accept(v));
        }

        public virtual IEnumerator<TElement> GetEnumerator()
        {
            return _elements.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
