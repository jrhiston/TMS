namespace TMS.Layer.ModelObjects
{
    public interface IElement<TVisitor>
    {
        TVisitor Accept(TVisitor visitor);
    }
}
