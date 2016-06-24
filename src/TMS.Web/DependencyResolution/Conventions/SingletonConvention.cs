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
            var genericTypeDefinition = contract.GetGenericTypeDefinition();

            return (genericTypeDefinition == typeof(IFactory<,>) ||
                   genericTypeDefinition == typeof(IDecoratorFactory<,,>) ||
                   genericTypeDefinition == typeof(IFilterFactory<>) ||
                   genericTypeDefinition == typeof(IReader<,>) ||
                   genericTypeDefinition == typeof(IQueryFactory<>) ||
                   genericTypeDefinition == typeof(IConverter<,>) ||
                   genericTypeDefinition == typeof(IInitialiser<,>) ||
                   genericTypeDefinition == typeof(ICreator<>));
        }
    }
}
