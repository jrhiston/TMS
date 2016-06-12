using System.Collections;
using System.Collections.Generic;

namespace TMS.Layer
{
    public class Maybe<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> values;

        public Maybe() : this(default(T))
        {
        }

        public Maybe(T value)
        {
            if (!Equals(default(T), null))
                values = new[] { value };
            else
                values = new T[0];
        }

        public IEnumerator<T> GetEnumerator()
        {
            return values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
