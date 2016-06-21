using System.Reflection;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.Layer.Data;

namespace TMS.Database.Converters
{
    public class Converter<TVisitor, TData, TEntity> : IDataConverter<TVisitor, TEntity> where TEntity : new() where TVisitor : Visitor<TData> where TData : IData
    {
        public Maybe<TEntity> Convert(TVisitor input)
        {
            var entityToReturn = new TEntity();
            var typeOfEntity = entityToReturn.GetType();

            var propertyMappings = input.PropertyMappings;

            foreach (var property in propertyMappings)
            {
                var propertyToSet = typeOfEntity.GetProperty(property.Name, BindingFlags.Public | BindingFlags.Instance);

                if (propertyToSet != null && propertyToSet.CanWrite)
                    propertyToSet.SetValue(entityToReturn, property.GetValue(input.DataObject));
                else
                    return new Maybe<TEntity>();
            }

            return new Maybe<TEntity>(entityToReturn);
        }
    }
}
