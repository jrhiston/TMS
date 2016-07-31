using StructureMap;
using System;
using System.Collections.Generic;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Readers;
using TMS.Layer.Repositories;

namespace Utility.StructureMap
{
    public class ObjectComposer<TInput, TOutput> : IObjectComposer<TOutput>, IReader<TInput, TOutput>
    {
        private readonly Container _container;
        private readonly HashSet<Type> _decorators;
        private readonly IQueryableRepository<TOutput, TInput> _repository;

        public ObjectComposer(Container container,
            IQueryableRepository<TOutput, TInput> repository)
        {
            _container = container;
            _repository = repository;
        }

        public Maybe<TOutput> Read(TInput key)
        {
            return _repository.Get(key);
        }

        public IObjectComposer<TOutput> Include<TDecorator>()
        {
            _decorators.Add(typeof(TDecorator));
            return this;
        }

        public Maybe<TOutput> GetResult<TData>(TData data, Maybe<TOutput> decoratee)
        {
            foreach (var instance in _decorators)
            {
                var type = typeof(IDecoratorConverter<,,>).MakeGenericType(data.GetType(), decoratee.GetType(), instance);

                dynamic decoratorConverter = _container.GetInstance(type);

                decoratee = decoratorConverter.Convert(data, decoratee);
            }

            return decoratee;
        }
    }
}
