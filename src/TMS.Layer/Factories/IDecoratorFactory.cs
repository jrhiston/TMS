using TMS.Layer.Data;

namespace TMS.Layer.Factories
{
    /// <summary>
    /// Use this class for creation of <paramref name="TDecorator"/> objects.
    ///
    /// All decorator factory classes should inherit from this interface.
    /// </summary>
    /// <typeparam name="TData">The data to inject</typeparam>
    /// <typeparam name="TDecoratee">The object that is being decorated.</typeparam>
    /// <typeparam name="TDecorator">The resultant decorated object.</typeparam>
    public interface IDecoratorFactory<TData, TDecoratee, TDecorator>
        where TData : IData
    {
        /// <summary>
        /// This method should decorate the <paramref name="decoratee"/> object with the <paramref name="data"/> object.
        ///
        /// This method should result in a new object that adds functionality to the existing <paramref name="decoratee"/>.
        /// </summary>
        /// <param name="data">The data to decorate with. The data must implement the IData interface.</param>
        /// <param name="decoratee">The object that is being decorated. This must implement the IModelObject interface.</param>
        /// <returns>An object that has decorated the given <paramref name="decoratee"/>.</returns>
        TDecorator Create(TData data, TDecoratee decoratee);
    }
}
