﻿using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using TMS.Layer.Persistence;
using TMS.Layer.Readers;
using TMS.Layer.Repositories;
using TMS.RepositoryLayer.Repositories;
using TMS.Web.DependencyResolution.Registries;

namespace TMS.Web.DependencyResolution
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
                c.For(typeof(IFilterableRepository<,>)).Singleton().Use(typeof(FilterableRepository<,>));
                c.For(typeof(IPersistableRepository<,>)).Singleton().Use(typeof(PersistableRepository<,>));
                c.For(typeof(IReader<,>)).Singleton().Use(typeof(Reader<,>));
                c.For(typeof(IListReader<,>)).Singleton().Use(typeof(ListReader<,>));
                c.For(typeof(IWriter<,>)).Singleton().Use(typeof(Writer<,>));
            });

            return container;
        }
    }
}
