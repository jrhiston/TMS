using System;
using TMS.Layer.Data;

namespace TMS.Layer.Visitors
{
    /// <summary>
    /// Implement this interface if the object is visited by a <see cref="IVisitor{TData}"/> object.
    /// </summary>
    /// <typeparam name="TVisitor">The type of the visitor</typeparam>
    /// <typeparam name="TData">The type of the data that the visitor expects</typeparam>
    public interface IVisited<TVisitor, TData>
        where TVisitor : IVisitor<TData>
        where TData : IData
    {
        /// <summary>
        /// A method that will accept and potentially pass data to a visitor.
        /// </summary>
        /// <param name="visitorFactory">A factory that will produce a visitor. It is a func to delay instantiation of the visitor if the instantiation is expensive, and can be delayed. Or the visited object decides it does not need to instantiate the visitor after all.</param>
        void Accept(Func<TVisitor> visitorFactory);
    }
}
