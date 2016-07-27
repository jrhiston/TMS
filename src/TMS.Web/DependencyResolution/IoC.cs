using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using TMS.Layer.Factories;
using TMS.Layer.Persistence;
using TMS.Layer.Readers;
using TMS.Layer.Repositories;
using TMS.ModelLayer;
using TMS.RepositoryLayer.Repositories;
using TMS.Web.DependencyResolution.Registries;

namespace TMS.Web.DependencyResolution
{
    public static class IoC
    {
        public static IContainer Initialize(IServiceCollection services)
        {
            var container = new Container();

            container.Configure(c =>
            {
                c.Populate(services);

                var standardRegistry = new StandardRegistry(container);

                c.AddRegistry(standardRegistry);

                c.For(typeof(IQueryableRepository<,>)).Singleton().Use(typeof(QueryableRepository<,>));
                c.For(typeof(IFilterableRepository<,>)).Singleton().Use(typeof(FilterableRepository<,>));
                c.For(typeof(IPersistableRepository<,>)).Singleton().Use(typeof(PersistableRepository<,>));
                c.For(typeof(IReader<,>)).Singleton().Use(typeof(Reader<,>));
                c.For(typeof(IListReader<,>)).Singleton().Use(typeof(ListReader<,>));
                c.For(typeof(IWriter<,>)).Singleton().Use(typeof(Writer<,>));
                c.For(typeof(IFactoryRegistrar)).Singleton().Use(typeof(FactoryRegistrar));
                c.For(typeof(IFactory<,>)).Singleton().Use(typeof(Factory<,>));
                c.For(typeof(IDecoratorFactory<,,>)).Singleton().Use(typeof(DecoratorFactory<,,>));
            });

            container.GetInstance<IFactoryRegistrar>().InitialiseModelLayer();

            return container;
        }
    }
}
