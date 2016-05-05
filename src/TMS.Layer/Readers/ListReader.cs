using System.Collections.Generic;
using TMS.Layer.Repositories;

namespace TMS.Layer.Readers
{
    public class ListReader<TFilterData, TReturn> : IListReader<TFilterData, TReturn>
    {
        private readonly IFilterableRepository<TReturn, TFilterData> _repository;

        public ListReader(IFilterableRepository<TReturn, TFilterData> repository)
        {
            _repository = repository;
        }

        public Maybe<IEnumerable<TReturn>> Read(TFilterData key) => _repository.List(key);
    }
}
