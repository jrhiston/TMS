using System.Collections.Generic;

namespace TMS.Layer.ErrorHandling
{
    public interface IValidationResult
    {
        bool HasAnyErrors { get; }
        List<IError> Errors { get; }
    }
}
