﻿using StructureMap;
using TMS.Web.DependencyResolution.Conventions;

namespace TMS.Web.DependencyResolution.Registries
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
                scan.Convention<SingletonConvention>();
            });
        }
    }
}