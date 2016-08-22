using System.Collections.Generic;
using TMS.Layer;
using TMS.Layer.Data;
using TMS.Layer.Filters;
using TMS.Layer.Repositories;

namespace Proto.ModelLayer.Infrastructure.Filters
{
    public class Filter<TReturnedModel> : IFilter<TReturnedModel>
    {
        private readonly IData _data;
        private readonly IQueryableRepository<IEnumerable<TReturnedModel>, IData> _repository;

        public Filter(IQueryableRepository<IEnumerable<TReturnedModel>, IData> repository, IData data)
        {
            _repository = repository;
            _data = data;
        }

        public Maybe<IEnumerable<TReturnedModel>> List()
        {
            return _repository.Get(_data);
        }
    }
}
