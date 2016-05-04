using System.Collections.Generic;
using TMS.Layer.Repositories;

namespace TMS.Layer.Readers
{
    public class Reader<TKey, TReturn, TFilterData> : IReader<TKey, Maybe<TReturn>>,
         IReader<TFilterData, Maybe<IEnumerable<TReturn>>>
    {
        private readonly IQueryableRepository<TReturn, TKey, TFilterData> _repository;

        public Reader(IQueryableRepository<TReturn, TKey, TFilterData> repository)
        {
            _repository = repository;
        }

        public Maybe<IEnumerable<TReturn>> Read(TFilterData key) => _repository.List(key);

        public Maybe<TReturn> Read(TKey key) => _repository.Get(key);
    }
}
