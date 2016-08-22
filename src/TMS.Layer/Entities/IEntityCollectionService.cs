using System;
using System.Collections;
using System.Collections.Generic;
using TMS.Layer.ModelObjects;

namespace TMS.Layer.Entities
{
    public interface IEntityCollectionService<TData, TEntity>
        where TData : IEnumerable
        where TEntity : class
    {
        void AddOrUpdate<TKey>(ICollection<TEntity> collection, TData data, Func<TData, TEntity> createItem, Func<TEntity, TKey, bool> equalityComparer) where TKey : class, IModelKey;
    }
}