namespace TMS.Layer.Conversion
{
    public interface IDecoratorConverter<TInput, TDecoratee, TOutput>
    {
        Maybe<TOutput> Convert(TInput input, TDecoratee decoratee);
    }
}
