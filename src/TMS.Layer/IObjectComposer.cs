using TMS.Layer;

namespace TMS.Layer
{
    public interface IObjectComposer<TOutput>
    {
        IObjectComposer<TOutput> Include<TDecoratee>();

        Maybe<TOutput> GetResult<TData>(TData data, Maybe<TOutput> decoratee);
    }
}