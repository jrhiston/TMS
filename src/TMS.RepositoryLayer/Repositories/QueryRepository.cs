using System.Collections.Generic;
using TMS.Layer;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;

namespace TMS.RepositoryLayer.Repositories
{
    public class QueryableRepository<TModelObject, TModelObjectKey, TFilter> : FilterableRepository<TModelObject, TFilter>, IQueryableRepository<TModelObject, TModelObjectKey, TFilter>
    {
        private readonly IQueryFactory<IQueryCommand<TFilter, IEnumerable<TModelObject>>> _listQueryFactory;
        private readonly IQueryFactory<IQueryCommand<TModelObjectKey, TModelObject>> _queryFactory;

        public QueryableRepository(IQueryFactory<IQueryCommand<TModelObjectKey, TModelObject>> queryFactory,
            IQueryFactory<IQueryCommand<TFilter, IEnumerable<TModelObject>>> listQueryFactory) : base(listQueryFactory)
        {
            _queryFactory = queryFactory;
            _listQueryFactory = listQueryFactory;
        }

        public Maybe<TModelObject> Get(TModelObjectKey key)
        {
            return _queryFactory
                .Create()
                .ExecuteCommand(key);
        }
    }
}
