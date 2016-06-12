using System.Collections.Generic;
using TMS.Layer;
using TMS.Layer.Factories;
using TMS.Layer.Repositories;

namespace TMS.RepositoryLayer.Repositories
{
    public class FilterableRepository<TModelObject, TFilterData> : IFilterableRepository<TModelObject, TFilterData>
    {
        private readonly IQueryFactory<IQueryCommand<TFilterData, IEnumerable<TModelObject>>> _listQueryFactory;

        public FilterableRepository(IQueryFactory<IQueryCommand<TFilterData, IEnumerable<TModelObject>>> listQueryFactory)
        {
            _listQueryFactory = listQueryFactory;
        }

        public Maybe<IEnumerable<TModelObject>> List(TFilterData filter)
        {
            return _listQueryFactory
                .Create()
                .ExecuteCommand(filter);
        }
    }
}
