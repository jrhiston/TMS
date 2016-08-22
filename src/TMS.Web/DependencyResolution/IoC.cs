using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using TMS.Layer.Entities;
using TMS.Layer.Persistence;
using TMS.Layer.Readers;
using TMS.Layer.Repositories;
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
                c.For(typeof(IPersistableRepository<,>)).Singleton().Use(typeof(PersistableRepository<,>));
                c.For(typeof(IReader<,>)).Singleton().Use(typeof(Reader<,>));
                c.For(typeof(IWriter<,>)).Singleton().Use(typeof(Writer<,>));
                c.For(typeof(IEntityService<,>)).Singleton().Use(typeof(EntityService<,>));
                c.For(typeof(IEntityCollectionService<,>)).Singleton().Use(typeof(EntityCollectionService<,>));
            });

            return container;
        }
    }
}
