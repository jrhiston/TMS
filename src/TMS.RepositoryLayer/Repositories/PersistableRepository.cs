using TMS.Layer;
using TMS.Layer.ModelObjects;
using TMS.Layer.Repositories;

namespace TMS.RepositoryLayer.Repositories
{
    public class PersistableRepository<TModelObject, TModelObjectKey> : IPersistableRepository<TModelObject, TModelObjectKey> where TModelObjectKey : IModelKey
    {
        private readonly INonQueryCommand<TModelObjectKey> _nonQueryCommand;
        private readonly IQueryCommand<TModelObject, TModelObjectKey> _persistCommandQueryFactory;

        public PersistableRepository(IQueryCommand<TModelObject, TModelObjectKey> persistCommandQueryFactory,
            INonQueryCommand<TModelObjectKey> nonQueryCommand)
        {
            _persistCommandQueryFactory = persistCommandQueryFactory;
            _nonQueryCommand = nonQueryCommand;
        }

        public void Delete(TModelObjectKey key) => _nonQueryCommand.ExecuteCommand(key);
        public Maybe<TModelObjectKey> Save(TModelObject data) => _persistCommandQueryFactory.ExecuteCommand(data);
    }
}
