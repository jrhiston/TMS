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
                scan.Assembly("TMS.ModelLayer");
                scan.Assembly("TMS.RepositoryLayer");
                scan.Assembly("TMS.Database");
                scan.Assembly("TMS.Web");
                scan.Convention<SingletonConvention>();
            });
        }
    }
}