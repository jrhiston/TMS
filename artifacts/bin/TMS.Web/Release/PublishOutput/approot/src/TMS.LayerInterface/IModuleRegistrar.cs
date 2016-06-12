using System;

namespace TMS.LayerInterface
{
    public interface IModuleRegistrar
    {
        TTo GetInstance<TTo>();

        void RegisterType<TFrom, TTo>(Func<IModuleRegistrar, TTo> creator, bool withInterception = false) where TTo : TFrom;

        void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;

        void RegisterTypeAsSingleton<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;
        void RegisterTypeAsSingleton(Type from, Type to, bool withInterception = false);

        void RegisterTypeWithPerRequestControlledLife<TFrom, TTo>(bool withInterception = false) where TTo : TFrom;
    }
}
