using System.Collections;
using System.Collections.Generic;
using System.Linq;

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
            if (!Equals(value, null))
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

    public static class Maybe
    {
        public static Maybe<T> ToMaybe<T>(this T value)
        {
            return new Maybe<T>(value);
        }

        public static Maybe<T> Empty<T>()
        {
            return new Maybe<T>();
        }
    }
}
