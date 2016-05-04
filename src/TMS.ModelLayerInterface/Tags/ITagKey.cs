using System;

namespace TMS.ModelLayerInterface.Tags
{
    public interface ITagKey : IEquatable<ITagKey>
    {
        long Identifier { get; set; }
    }
}
