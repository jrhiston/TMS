using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace TMS.Layer.Pipes
{
    public class CompositePipe<T> : IPipe<T>, IEnumerable<IPipe<T>>
    {
        private readonly IEnumerable<IPipe<T>> _pipes;

        public CompositePipe(params IPipe<T>[] pipes)
        {
            _pipes = pipes;
        }

        public T Pipe(T item)
        {
            return _pipes.Aggregate(item, (x, p) => p.Pipe(x));
        }

        public IEnumerator<IPipe<T>> GetEnumerator()
        {
            return _pipes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
