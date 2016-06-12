namespace TMS.Layer.ErrorHandling
{
    public interface IValidator<T>
    {
        IValidationResult Validate(T obj);
    }
}
