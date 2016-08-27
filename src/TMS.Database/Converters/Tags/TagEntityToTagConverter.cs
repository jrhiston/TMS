using System.Collections.Generic;
using TMS.Data.Entities.Tags;
using TMS.Layer;
using TMS.Layer.Conversion;
using TMS.ModelLayer;
using TMS.ModelLayer.People;
using TMS.ModelLayer.Tags;
using TMS.ModelLayer.Tags.CanSetOnActivities;

namespace TMS.Database.Converters.Tags
{
    public class TagEntityToTagConverter : IConverter<TagEntity, Tag>
    {
        public Maybe<Tag> Convert(TagEntity tagEntity) => new Tag(GetElements(tagEntity)).ToMaybe();

        private static IEnumerable<ITagElement> GetElements(TagEntity tagEntity) => new List<ITagElement>
        {
            new Name(tagEntity.Name),
            new CreationDate(tagEntity.Created),
            new Description(tagEntity.Description),
            CanSetOnActivityBase.GetInstance(tagEntity.CanSetOnActivity),
            new Reusable(tagEntity.Reusable),
            new TagKey(tagEntity.Id),
            new PersonKey(tagEntity.AuthorId)
        };
    }
}
