using System;
using System.Collections;
using System.Collections.Generic;
using TMS.Layer.ModelObjects;

namespace TMS.Layer.Entities
{
    public interface IEntityService<TData, TEntity>
        where TEntity : class, new()
        where TData : IEnumerable
    {
        TEntity AddAndSave(TData data);

        TEntity Save<TKey>(TData data, Func<TKey, IEnumerable<TEntity>, TEntity> entityFinder) 
            where TKey : class, IModelKey;

        TEntity UpdateAndSave<TKey>(TData data, TKey key, Func<TKey, IEnumerable<TEntity>, TEntity> entityFinder) 
            where TKey : class, IModelKey;
    }
}