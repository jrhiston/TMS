namespace TMS.Layer.Data
{
    public interface IDecoratedData<out TModelObject, in TDecoratedObject>
    {
        TModelObject Initialise(TDecoratedObject obj);
    }
}
