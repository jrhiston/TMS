namespace TMS.Layer.Conversion
{
    public interface IConverter<in TIn, TOut>
    {
        Maybe<TOut> Convert(TIn input);
    }
}
