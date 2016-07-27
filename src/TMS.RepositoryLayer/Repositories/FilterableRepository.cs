using System.Collections.Generic;
using TMS.Layer;
using TMS.Layer.Repositories;

namespace TMS.RepositoryLayer.Repositories
{
    public class FilterableRepository<TModelObject, TFilterData> : IFilterableRepository<TModelObject, TFilterData>
    {
        private readonly IQueryCommand<TFilterData, IEnumerable<TModelObject>> _listQueryFactory;

        public FilterableRepository(IQueryCommand<TFilterData, IEnumerable<TModelObject>> listQueryFactory)
        {
            _listQueryFactory = listQueryFactory;
        }

        public Maybe<IEnumerable<TModelObject>> List(TFilterData filter) => _listQueryFactory.ExecuteCommand(filter);
    }
}
