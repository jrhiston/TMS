using TMS.Data.Entities.Tags;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.ModelLayer;
using TMS.ModelLayer.Tags;

namespace TMS.Database.Converters.Tags
{
    public class TagEntityToTagNameConverter : IConverter<TagEntity, ITagElement>
    {
        public Maybe<ITagElement> Convert(TagEntity input) => new Maybe<ITagElement>(new Name(input.Name));
    }
}
