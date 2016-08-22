using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMS.Layer.ModelObjects;

namespace TMS.Layer.Entities
{
    public class EntityCollectionService<TData, TEntity> : IEntityCollectionService<TData, TEntity> where TData : IEnumerable where TEntity : class
    {
        public void AddOrUpdate<TKey>(ICollection<TEntity> collection,
            TData data,
            Func<TData, TEntity> createItem,
            Func<TEntity, TKey, bool> equalityComparer) where TKey : class, IModelKey
        {
            var key = data.OfType<TKey>().FirstOrDefault();

            if (key == null)
                collection.Add(createItem(data));
            else
                AddExistingTag(key, data, collection, createItem, equalityComparer);
        }

        private void AddExistingTag<TKey>(TKey tagId, 
            TData data,
            ICollection<TEntity> collection,
            Func<TData, TEntity> updateItem, 
            Func<TEntity, TKey, bool> equalityComparer) where TKey : class, IModelKey
        {
            var existingEntity = collection.FirstOrDefault(t => equalityComparer(t, tagId));

            if (existingEntity == null)
            {
                collection.Add(updateItem(data));
            }
        }
    }
}
