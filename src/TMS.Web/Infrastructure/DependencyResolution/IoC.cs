using Microsoft.Extensions.DependencyInjection;
using Proto.CMS.Infrastructure.DependencyResolution.Registries;
using StructureMap;
using TMS.Layer.Repositories;
using TMS.RepositoryLayer.Repositories;

namespace Proto.CMS.Infrastructure.DependencyResolution
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

                c.For(typeof(IQueryableRepository<,,>)).Singleton().Use(typeof(QueryableRepository<,,>));
            });

            container.Configure(c =>
            {
                c.AddRegistry(new ProjectRegistry(container));
            });

            return container;
        }
    }
}
