using System;
using System.Collections.Generic;

namespace TMS.Layer.Factories
{
    public class FactoryRegistrar : IFactoryRegistrar
    {
        private readonly Dictionary<Type, Func<object>> _queryFactories = new Dictionary<Type, Func<object>>();
        private readonly Dictionary<Type, Func<object, object>> _factories = new Dictionary<Type, Func<object, object>>();
        private readonly Dictionary<Type, Func<object, object, object>> _decoratorFactories = new Dictionary<Type, Func<object, object, object>>();

        public T Create<T, R>(R data) where T : class
        {
            Func<object, object> constructor = null;
            if (_factories.TryGetValue(typeof(R), out constructor))
                return constructor(data) as T;

            throw new ArgumentException("No type registered for this data type.");
        }

        public T Create<T, R>(R data, object decoratee) where T : class
        {
            Func<object, object, object> constructor = null;
            if (_decoratorFactories.TryGetValue(typeof(R), out constructor))
                return constructor(data, decoratee) as T;

            throw new ArgumentException("No type registered for this data type.");
        }

        public T Create<T>() where T : class
        {
            Func<object> constructor = null;
            if (_queryFactories.TryGetValue(typeof(T), out constructor))
                return constructor() as T;

            throw new ArgumentException("No type registered for this data type.");
        }

        public void Register<T, D>(Func<T, D, object> ctor, bool overwrite = false) where T : class where D : class
        {
            Func<object, object, object> ctorOfType = (obj1, obj2) => ctor(obj1 as T, obj2 as D);

            if (_decoratorFactories.ContainsKey(typeof(T)))
            {
                if (!overwrite)
                    throw new InvalidOperationException($"A constructor for data type {typeof(T)} already exists.");

                _decoratorFactories[typeof(T)] = ctorOfType;
            }
            else
                _decoratorFactories.Add(typeof(T), ctorOfType);
        }

        public void Register<T>(Func<T, object> ctor, bool overwrite = false) where T : class
        {
            Func<object, object> ctorOfType = (obj) => ctor(obj as T);

            if (_factories.ContainsKey(typeof(T)))
            {
                if (!overwrite)
                    throw new InvalidOperationException($"A constructor for data type {typeof(T)} already exists.");

                _factories[typeof(T)] = ctorOfType;
            }
            else
                _factories.Add(typeof(T), ctorOfType);
        }

        public void Register<T>(Func<object> ctor, bool overwrite = false) where T : class
        {
            if (_queryFactories.ContainsKey(typeof(T)))
            {
                if (!overwrite)
                    throw new InvalidOperationException($"A constructor for data type {typeof(T)} already exists.");

                _queryFactories[typeof(T)] = ctor;
            }
            else
                _queryFactories.Add(typeof(T), ctor);
        }
    }

    public interface IFactoryRegistrar
    {
        T Create<T>() where T : class;
        T Create<T, R>(R data) where T : class;
        T Create<T, R>(R data, object decoratee) where T : class;

        void Register<T>(Func<object> ctor, bool overwrite = false) where T : class;
        void Register<T>(Func<T, object> ctor, bool overwrite = false) where T : class;
        void Register<T, D>(Func<T, D, object> ctor, bool overwrite = false) where T : class where D : class;
    }
}
