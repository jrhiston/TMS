using Proto.CMS.Infrastructure.DependencyResolution.Conventions;
using StructureMap;

namespace Proto.CMS.Infrastructure.DependencyResolution.Registries
{
    public class StandardRegistry : Registry
    {
        public StandardRegistry(IContainer container)
        {
            //For<IModuleRegistrar>().Use<ModuleRegistrar>();

            Scan(scan =>
            {
                scan.Assembly("Proto.ModelLayer");
                scan.Assembly("Proto.RepositoryLayer");
                scan.Convention<SingletonConvention>();
            });
        }
    }
}