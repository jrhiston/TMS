using System.Collections.Generic;
using TMS.Layer.Data;
using TMS.Layer.Filters;
using TMS.Layer.Repositories;

namespace Proto.ModelLayer.Infrastructure.Filters
{
    public class FilterFactory<TReturnedModel> : IFilterFactory<TReturnedModel>
    {
        private readonly IQueryableRepository<IEnumerable<TReturnedModel>, IData> _repository;

        public FilterFactory(IQueryableRepository<IEnumerable<TReturnedModel>, IData> repository)
        {
            _repository = repository;
        }

        public IFilter<TReturnedModel> Create(IData data)
        {
            return new Filter<TReturnedModel>(_repository, data);
        }
    }
}
