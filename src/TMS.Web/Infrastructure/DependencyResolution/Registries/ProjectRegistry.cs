using Proto.CMS.Infrastructure.DependencyResolution.Conventions;
using StructureMap;

namespace Proto.CMS.Infrastructure.DependencyResolution.Registries
{
    public class ProjectRegistry : Registry
    {
        public ProjectRegistry(IContainer container)
        {
            Scan(scan =>
            {
                scan.Assembly("Project.ModelLayer");
                scan.Assembly("Project.RepositoryLayer");
                scan.Convention<SingletonConvention>();
            });
        }
    }
}
