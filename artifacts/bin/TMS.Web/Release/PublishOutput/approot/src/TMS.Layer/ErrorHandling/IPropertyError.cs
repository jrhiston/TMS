namespace TMS.Layer.ErrorHandling
{
    public interface IPropertyError : IError
    {
        string PropertyName { get; set; }
    }
}
