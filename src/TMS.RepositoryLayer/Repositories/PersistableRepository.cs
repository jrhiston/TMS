using TMS.Layer;
using TMS.Layer.Factories;
using TMS.Layer.ModelObjects;
using TMS.Layer.Repositories;

namespace TMS.RepositoryLayer.Repositories
{
    public class PersistableRepository<TModelObject, TModelObjectKey> : IPersistableRepository<TModelObject, TModelObjectKey> where TModelObjectKey : IModelKey
    {
        private readonly IQueryFactory<INonQueryCommand<TModelObjectKey>> _nonQueryCommand;
        private readonly IQueryFactory<IQueryCommand<TModelObject, TModelObjectKey>> _persistCommandQueryFactory;

        public PersistableRepository(IQueryFactory<IQueryCommand<TModelObject, TModelObjectKey>> persistCommandQueryFactory,
            IQueryFactory<INonQueryCommand<TModelObjectKey>> nonQueryCommand)
        {
            _persistCommandQueryFactory = persistCommandQueryFactory;
            _nonQueryCommand = nonQueryCommand;
        }

        public void Delete(TModelObjectKey key)
        {
            _nonQueryCommand.Create().ExecuteCommand(key);
        }

        public Maybe<TModelObjectKey> Save(TModelObject data)
        {
            return _persistCommandQueryFactory.Create().ExecuteCommand(data);
        }
    }
}
