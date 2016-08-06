using StructureMap.Graph;
using StructureMap;
using StructureMap.Graph.Scanning;
using System.Reflection;
using System.Linq;
using TMS.Layer.Factories;
using TMS.Layer.Filters;
using TMS.Layer.Readers;
using TMS.Layer.Conversion;
using TMS.Layer.Initialisers;
using TMS.Layer.Creators;
using TMS.Database;
using TMS.Layer.Repositories;
using TMS.Layer.Builders;

namespace TMS.Web.DependencyResolution.Conventions
{
    public class SingletonConvention : IRegistrationConvention
    {
        public void ScanTypes(TypeSet types, Registry registry)
        {
            foreach (var type in types.FindTypes(TypeClassification.Concretes | TypeClassification.Closed))
            {
                foreach (var typeInterface in type.GetInterfaces()
                    .Where(contract => contract.GetTypeInfo().IsGenericType && TypeIsToBeRegistered(contract)))
                {
                    registry.For(typeInterface).Use(type).Singleton();
                }
            }
        }

        private static bool TypeIsToBeRegistered(System.Type contract)
        {
            var definition = contract.GetGenericTypeDefinition();

            return (definition == typeof(IConverter<,>) ||
                   definition == typeof(IInitialiser<,>) ||
                   definition == typeof(ICreator<>) ||
                   definition == typeof(IDatabaseContextFactory<>) ||
                   definition == typeof(INonQueryCommand<>) ||
                   definition == typeof(IQueryCommand<,>) || 
                   definition == typeof(ISaveCommand) ||
                   definition == typeof(IEntityBuilder<,>));
        }
    }
}
