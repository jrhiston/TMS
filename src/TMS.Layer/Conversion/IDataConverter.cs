namespace TMS.Layer.Conversion
{
    public interface IDataConverter<in TIn, TOut>
    {
        Maybe<TOut> Convert(TIn input);
    }
}
