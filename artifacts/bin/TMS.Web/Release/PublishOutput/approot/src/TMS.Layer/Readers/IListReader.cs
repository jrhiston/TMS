using System.Collections.Generic;

namespace TMS.Layer.Readers
{
    public interface IListReader<in T, R>
    {
        Maybe<IEnumerable<R>> Read(T key);
    }
}
