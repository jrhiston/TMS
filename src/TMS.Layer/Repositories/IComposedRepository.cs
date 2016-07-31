namespace TMS.Layer.Repositories
{
    public interface IComposedRepository<TIn, TOut>
    {
        Maybe<TOut> Get(TIn key, IObjectComposer<TOut> composer);
    }
}
