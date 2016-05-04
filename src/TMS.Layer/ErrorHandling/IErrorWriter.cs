namespace TMS.Layer.ErrorHandling
{
    public interface IErrorWriter
    {
        void AddError(IError error);

        void AddError(IPropertyError propertyError);
    }
}
