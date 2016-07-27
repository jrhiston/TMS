using TMS.Layer.Data;

namespace TMS.Layer.Factories
{
    public class DecoratorFactory<TData, TDecoratee, TDecorator> : IDecoratorFactory<TData, TDecoratee, TDecorator> where TData : IData where TDecorator : class
    {
        private readonly IFactoryRegistrar _factoryConstructor;

        public DecoratorFactory(IFactoryRegistrar factoryConstructor)
        {
            _factoryConstructor = factoryConstructor;
        }

        public TDecorator Create(TData data, TDecoratee decoratee) => _factoryConstructor.Create<TDecorator, TData>(data, decoratee);
    }

    public interface IDecoratorFactory<TData, TDecoratee, TDecorator> where TData : IData where TDecorator : class
    {
        TDecorator Create(TData data, TDecoratee decoratee);
    }
}
