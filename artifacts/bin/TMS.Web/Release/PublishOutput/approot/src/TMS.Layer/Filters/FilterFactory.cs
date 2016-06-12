using TMS.Layer.Data;
using TMS.Layer.Filters;
using TMS.Layer.Repositories;

namespace Proto.ModelLayer.Infrastructure.Filters
{
    public class FilterFactory<TReturnedModel> : IFilterFactory<TReturnedModel>
    {
        private readonly IFilterableRepository<TReturnedModel, IData> _repository;

        public FilterFactory(IFilterableRepository<TReturnedModel, IData> repository)
        {
            _repository = repository;
        }

        public IFilter<TReturnedModel> Create(IData data)
        {
            return new Filter<TReturnedModel>(_repository, data);
        }
    }
}
