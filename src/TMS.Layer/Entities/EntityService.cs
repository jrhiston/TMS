using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMS.Layer.Builders;
using TMS.Layer.Data;
using TMS.Layer.ModelObjects;

namespace TMS.Layer.Entities
{
    public class EntityService<TData, TEntity> : IEntityService<TData, TEntity>
            where TEntity : class, new()
            where TData : IEnumerable
    {
        private readonly IDataContextFactory<TEntity> _contextFactory;
        private readonly IEntityBuilder<TData, TEntity> _entityBuilder;

        public EntityService(IDataContextFactory<TEntity> context,
            IEntityBuilder<TData, TEntity> entityBuilder)
        {
            _contextFactory = context;
            _entityBuilder = entityBuilder;
        }

        public TEntity Save<TKey>(TData data, Func<TKey, IEnumerable<TEntity>, TEntity> entityFinder) where TKey : class, IModelKey
        {
            TEntity entity;

            var key = data.OfType<TKey>()?.FirstOrDefault();
            if (key == null)
                entity = AddAndSave(data);
            else
                entity = UpdateAndSave(data, key, entityFinder);

            return entity;
        }

        public TEntity UpdateAndSave<TKey>(TData data, TKey key, Func<TKey, IEnumerable<TEntity>, TEntity> entityFinder) where TKey : class, IModelKey
        {
            using (var context = _contextFactory.Create())
            {
                TEntity entity = entityFinder(key, context.Entities);

                if (entity == null)
                    throw new InvalidOperationException($"Could not find activity with id {key.Identifier}");

                AssignToEntity(data, entity);

                context.SaveChanges();

                return entity;
            }
        }

        public TEntity AddAndSave(TData data)
        {
            using (var context = _contextFactory.Create())
            {
                TEntity entity = new TEntity();

                AssignToEntity(data, entity);

                context.Entities.Add(entity);

                context.SaveChanges();

                return entity;
            }
        }

        private void AssignToEntity(TData data, TEntity entity) =>  _entityBuilder.Update(data, entity);
    }
}
