using Microsoft.Extensions.DependencyInjection;
using Proto.CMS.Infrastructure.DependencyResolution.Registries;
using StructureMap;
using TMS.Layer.Readers;
using TMS.Layer.Repositories;
using TMS.RepositoryLayer.Repositories;

namespace TMS.Web.Infrastructure.DependencyResolution
{
    public class IoC
    {
        public static IContainer Initialize(IServiceCollection services)
        {
            var container = new Container();

            container.Configure(c =>
            {
                c.Populate(services);

                c.AddRegistry(new StandardRegistry(container));

                c.For(typeof(IQueryableRepository<,>)).Singleton().Use(typeof(QueryableRepository<,>));
                c.For(typeof(IReader<,>)).Singleton().Use(typeof(Reader<,>));
                c.For(typeof(IListReader<,>)).Singleton().Use(typeof(ListReader<,>));
            });

            return container;
        }
    }
}
