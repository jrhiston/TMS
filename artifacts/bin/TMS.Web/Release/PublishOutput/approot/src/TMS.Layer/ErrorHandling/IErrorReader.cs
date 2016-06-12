using System.Collections.Generic;

namespace TMS.Layer.ErrorHandling
{
    public interface IErrorReader
    {
        IEnumerable<IError> Errors { get; }

        bool HasAnyErrors();
    }
}
