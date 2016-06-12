using TMS.ModelLayerInterface.Tags;

namespace TMS.ModelLayer.Tags
{
    public class TagKey : ITagKey
    {
        public long Identifier { get; set; }

        public bool Equals(ITagKey other)
        {
            return other.Identifier == Identifier;
        }
    }
}
