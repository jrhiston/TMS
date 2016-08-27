using System;

namespace TMS.Layer.Extensions
{
    public interface IIdentifiable<T> : IEquatable<IIdentifiable<T>>
    {
        T Identifier { get; }
    }
}
