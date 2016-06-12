using TMS.Layer;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;

namespace TMS.RepositoryLayer.Repositories
{
    public class QueryableRepository<TModelObject, TModelObjectKey> : IQueryableRepository<TModelObject, TModelObjectKey>
    {
        private readonly IQueryFactory<IQueryCommand<TModelObjectKey, TModelObject>> _queryFactory;

        public QueryableRepository(IQueryFactory<IQueryCommand<TModelObjectKey, TModelObject>> queryFactory)
        {
            _queryFactory = queryFactory;
        }

        public Maybe<TModelObject> Get(TModelObjectKey key) => _queryFactory.Create().ExecuteCommand(key);
    }
}
