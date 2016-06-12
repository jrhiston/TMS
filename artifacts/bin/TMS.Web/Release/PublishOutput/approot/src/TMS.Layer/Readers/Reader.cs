using TMS.Layer.Repositories;

namespace TMS.Layer.Readers
{
    public class Reader<TKey, TReturn> : IReader<TKey, TReturn>
    {
        private readonly IQueryableRepository<TReturn, TKey> _repository;

        public Reader(IQueryableRepository<TReturn, TKey> repository)
        {
            _repository = repository;
        }

        public Maybe<TReturn> Read(TKey key) => _repository.Get(key);
    }
}
