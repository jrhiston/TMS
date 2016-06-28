using Microsoft.Extensions.DependencyInjection;
using TMS.Database.Entities.Areas;
using TMS.Database.Entities.People;
using TMS.Layer;

namespace TMS.Database
{
    internal class DatabaseServicesInitialiser : IServicesInitialiser<IDbContextTypeProvider>
    {
        public void Initialise(IServiceCollection services, IDbContextTypeProvider serviceDataProvider)
        {
            if (serviceDataProvider == null)
                throw new MustProvideServiceDataProviderException("Must provide data when initialising the database services.");

            var dbContextType = serviceDataProvider.GetDbContextType();

            if (dbContextType == null)
                throw new DbContextMustBeProvidedException();

            services.AddTransient(typeof(IDatabaseContextFactory<AreaEntity>), dbContextType);
            services.AddTransient(typeof(IDatabaseContextFactory<PersonEntity>), dbContextType);
        }
    }

    public static class DatabaseServicesExtensions
    {
        public static void AddTMSDatabaseServices(this IServiceCollection services, IDbContextTypeProvider serviceDataProvider) => new DatabaseServicesInitialiser().Initialise(services, serviceDataProvider);
    }
}
